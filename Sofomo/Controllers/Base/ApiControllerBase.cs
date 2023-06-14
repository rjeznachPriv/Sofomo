using System.Data.Entity.Core;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sofomo.Data;
using Sofomo.Domain.Exceptions;
using Sofomo.Logic;
using Sofomo.Logic.Queries.Factories;

namespace Sofomo.Api.Controllers.Base
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IQueryFactory queryFactory;
        protected ICommandFactory commandFactory;

        public ApiControllerBase(AppDbContext context, IMapper mapper)
        {
            queryFactory = new QueryFactory(context, mapper);
            commandFactory = new CommandFactory(context, mapper);
        }

        protected IActionResult DoQuery(IQuery query)
        {
            return ModelState.IsValid ? TryQuery(query) : new BadRequestResult();
        }

        protected IActionResult DoCommand(ICommand command)
        {
            return ModelState.IsValid ? TryCommand(command) : new BadRequestResult();
        }

        private IActionResult TryQuery(IQuery query)
        {
            try { 
                return new OkObjectResult(query.Execute()); 
            }
            catch (NotFoundException ex) 
            {
                ModelState.AddModelError(ex.Message, ex);
                return new NotFoundResult();
            }
            catch (ObjectNotFoundException ex)
            {
                ModelState.AddModelError(ex.Message, ex);
                return new NotFoundResult();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(ex.Message, ex);
                return new BadRequestResult();
            }
        }

        private IActionResult TryCommand(ICommand command)
        {
            try
            {
                command.Execute();
                return new OkResult();
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(ex.Message, ex);
                return new NotFoundResult();
            }
            catch (ObjectNotFoundException ex)
            {
                ModelState.AddModelError(ex.Message, ex);
                return new NotFoundResult();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(ex.Message, ex);
                return new BadRequestResult();
            }
        }
    }
}
