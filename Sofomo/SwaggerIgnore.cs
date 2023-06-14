using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Sofomo.Api
{
    public class SwaggerIgnore : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action.ActionName.Equals("Execute"))
                action.ApiExplorer.IsVisible = false;
        }
    }
}
