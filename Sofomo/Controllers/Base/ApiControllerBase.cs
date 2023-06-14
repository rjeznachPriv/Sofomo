using System.Data.Entity.Core;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Sofomo.Data;
using Sofomo.Domain.Exceptions;
using Sofomo.Logic;
using Sofomo.Logic.DTOs;
using Sofomo.Logic.Queries.Factories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Sofomo.Api.Controllers.Base
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IQueryFactory queryFactory;
        protected ICommandFactory commandFactory;

        public ApiControllerBase(AppDbContext context)
        {
            queryFactory = new QueryFactory(context);
            commandFactory = new CommandFactory(context);
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
