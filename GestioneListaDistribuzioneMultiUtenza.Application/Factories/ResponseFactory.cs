using GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Factories
{
    public class ResponseFactory
    {
        public static BaseResponse<T> WithSuccess<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = true;
            response.Result = result;
            return response;
        }

        public static BaseResponse<T> WithError<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = false;
            response.Result = result;
            return response;
        }
    }
}
