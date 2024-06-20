using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TerceiroSetor.Api.Middlewares;
using TerceiroSetor.Application.Notifications;

namespace TerceiroSetor.Api.Controllers
{
    [ApiController]
    [RequiredHeader("X-Tenant")]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        protected MainController(INotificator notificator) => _notificator = notificator;
        protected bool IsValidSubmit() => !_notificator.HasNotification();
        protected void NotifyError(string mensagem) => _notificator.AddNotification(mensagem);
        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValidSubmit())
            {
                return Ok(result);
            }

            var errors = _notificator.GetNotifications();

            if (errors.Count() == 1 && errors.First() == "NotFound")
            {
                return NotFound();
            }

            return UnprocessableEntity(new { Messages = errors.ToArray() } );
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyModelError(modelState);
            return CustomResponse();
        }

        protected void NotifyModelError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }
    }
}
