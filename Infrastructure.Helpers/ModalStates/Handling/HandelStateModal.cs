using Infrastructure.Helpers.ModalStates.Models;
using System;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using System.Linq;
using Infrastructure.Helpers.ResponseCodes;
using Elmah;

namespace Infrastructure.Helpers.ModalStates.Handling
{
    public static class HandelStateModal
    {
        public static ModalStateResponse HandelModalErrors(ModelStateDictionary model)
        {
            try
            {
                var errors = new List<ModalStateResponse>();
                foreach (var key in model.Keys)
                {
                    var modelStateVal = model[key];
                    foreach (var error in modelStateVal.Errors)
                    {
                        var responseCode = error.ErrorMessage;
                        var message = CodeKeys.SearchResponsesCodes()?.FirstOrDefault(s => s.Key == responseCode).Value;
                        if (string.IsNullOrEmpty(responseCode) && (error.Exception.Message.Contains("convert string")))
                        {
                            var invalidKey = key.Substring(key.LastIndexOf(".") + 1) + " " + "is Invalid";
                            responseCode = CodeKeys.SearchResponsesCodes().FirstOrDefault(s => s.Value.Contains(invalidKey)).Key;
                            message = CodeKeys.SearchResponsesCodes().FirstOrDefault(s => s.Key == responseCode).Value;
                        }
                        if (errors.FirstOrDefault(x => x.Key == key) == null)
                        {

                            errors.Add(new ModalStateResponse()
                            {
                                Key = key.Substring(key.LastIndexOf(".") + 1),
                                ResponseMessage = !string.IsNullOrEmpty(message) ? message : key.Substring(key.LastIndexOf(".") + 1) + " " + "is Invalid json value",
                                ResponseCode = !string.IsNullOrEmpty(responseCode) && int.TryParse(responseCode, out _) ? int.Parse(responseCode) : 500
                            });
                        }

                    }
                }
                return errors.FirstOrDefault();


            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
    }
}
