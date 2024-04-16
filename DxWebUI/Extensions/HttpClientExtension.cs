using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using System.Net.Http.Json;

namespace DxWebUI.Extensions
{
    public static class HttpClientExtension
    {
        public async static Task<IDataResult<TResult>> PostGetServiceResponseDataResultAsync<TResult, TPostValue>(
            this HttpClient Client,
        string Url,
            TPostValue PostValue)
        {
            
            var httpreqres = await Client.PostAsJsonAsync(Url, PostValue);
            var response = await httpreqres.Content.ReadFromJsonAsync<DataResult<TResult>>();
             return response;
        }

        public async static Task<IResult> PostGetServiceResponseResultAsync<TPostValue>(
            this HttpClient Client,
        string Url,
            TPostValue PostValue)
        {

            var httpreqres = await Client.PostAsJsonAsync(Url, PostValue);
            try
            {
                var response = await httpreqres.Content.ReadFromJsonAsync<Result>();
                return response;
            }
            catch (Exception)
            {

            }
            return new ErrorResult();
        }

        public async static Task<IResult> DeleteServiceResponseResultAsync(
            this HttpClient Client,
        string Url,
            int? PostValue)
        {

            var httpreqres = await Client.PostAsJsonAsync(Url, PostValue);
            try
            {
                return await httpreqres.Content.ReadFromJsonAsync<Result>();
            }
            catch (Exception)
            {

            }
            return new ErrorResult();
        }

        public async static Task<IDataResult<TResult>> GetServiceResponseDataResultAsync<TResult>(
            this HttpClient Client,
        string Url)
        {

            //var httpreqres = await Client.GetFromJsonAsync(Url);

            //var httpreqres = await Client.PostAsJsonAsync(Url, PostValue);
           // var response = await httpreqres.Content.ReadFromJsonAsync<DataResult<TResult>>();
            //return response;

            var httpRes = await Client.GetFromJsonAsync<DataResult<TResult>>(Url);
            return httpRes;
        }
    }
}
