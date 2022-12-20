using Core.Domain.Models.AppModels;
using Core.Domain.Models.DTO.Notification;
using Core.Domain.Models.DTO.Response;
using Infrastructure.Helpers.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IPushNotification
{
   public interface IPushNotificationService : IAppService<GovTalkMessage>
    {

        Task<List<NotificationsResponseResult>> PushNotification(List<requests> requests);

        Task CertificateValidationCallback();
    }
}
