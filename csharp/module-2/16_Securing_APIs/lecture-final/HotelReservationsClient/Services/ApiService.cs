﻿using HotelReservationsClient.Utility;
using RestSharp;
using System.Net.Http;

namespace HotelReservationsClient.Services
{
    public class ApiService
    {
        protected static RestClient client = null;

        public ApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        /// <summary>
        /// Checks RestSharp response for errors. If error, writes a log message and throws an exception 
        /// if the call was not successful. If no error, just returns to caller.
        /// </summary>
        /// <param name="response">Response returned from a RestSharp method call.</param>
        /// <param name="action">Description of the action the application was taking. Written to the log file for context.</param>
        protected void CheckForError(IRestResponse response, string action)
        {
            string message = "";
            string messageDetails = "";
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                message = $"Error occurred in '{action}' - unable to reach server.";
                messageDetails = $"Action: {action}\n" +
                    $"\tResponse status was '{response.ResponseStatus}'.";
                if (response.ErrorException != null)
                {
                    messageDetails += $"\n\t{response.ErrorException.Message}";
                }
            }
            else if (!response.IsSuccessful)
            {

                //if(response.statuscode == system.net.httpstatuscode.unauthorized) 
                // {     message = $"authorization si required and the user hasn't logged in.";   }
                // else if (responselstatuscode == system.net.httpscatuscode.forbidden) 
                // {  message = $"the suer doesn't have permission.";   }

                // else 
                // {  message = $"an http error occurred.";
                message = $"An http error occurred.";
                messageDetails = $"Action: {action}\n" +
                    $"\tResponse: {(int)response.StatusCode} {response.StatusDescription}";
            }
            if (message.Length > 0)
            {
                BasicLogger.Log($"{message}\n\t{messageDetails}\n");
                throw new HttpRequestException(message, response.ErrorException);
            }
        }
    }
}
