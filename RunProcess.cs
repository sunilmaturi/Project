using System;
using AuthorizeNet.Api.Controllers.Bases;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Utilities;

namespace net.authorize.sample
{
    class RunProcess
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Please pass AuthorizeCreditCard as param");
            }
            else if (args.Length == 1)
            {
                RunMethod(args[0]);
                return;
            }

            Console.ReadLine();
        }

        private static void RunMethod(String methodName)
        {
            const string apiLoginId = "4a3R7kV68";
            const string transactionKey = "5FY567BSh2r994N2";          
            const decimal amount = 53.34m;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment.HttpUseProxy = AuthorizeNet.Environment.getBooleanProperty(Constants.HttpsUseProxy);

            if (ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment.HttpUseProxy)
            {
                ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment.HttpUseProxy = AuthorizeNet.Environment.getBooleanProperty(Constants.HttpsUseProxy);
                ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment.HttpsProxyUsername = AuthorizeNet.Environment.GetProperty(Constants.HttpsProxyUsername);
                ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment.HttpsProxyPassword = AuthorizeNet.Environment.GetProperty(Constants.HttpsProxyPassword);
                ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment.HttpProxyHost = AuthorizeNet.Environment.GetProperty(Constants.HttpsProxyHost);
                ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment.HttpProxyPort = AuthorizeNet.Environment.getIntProperty(Constants.HttpsProxyPort);
            }

            switch (methodName)
            {
                case "AuthorizeCreditCard":
                    AuthorizeCreditCard.Run(apiLoginId, transactionKey, amount);
                    break;
                default:
                    break;
            }
        }
    }
}
