﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EthWidget
{
    public static class ETHRequest
    {
        private static readonly string ethPriceRequest = "https://api.etherscan.io/api?module=stats&action=ethprice&apikey=";

        private static readonly string ethGasRequest = "https://api.etherscan.io/api?module=gastracker&action=gasoracle&apikey=";

        private static readonly string ethBlockRequest = "https://api.etherscan.io/api?module=block&action=getblockreward&blockno={blocknum}&apikey=";

        private static readonly string ethWalletRequest = "https://api.etherscan.io/api?module=account&action=balance&address={address}&tag=latest&apikey=";

        private static string Send(string request)
        {
            string result;
            using (WebClient webClient = new WebClient())
            {
                result = webClient.DownloadString(request);
            }
            return result;
        }

        public static void GetPrice(string api)
        {
            string request = ethPriceRequest;
            if (api != null)
                request += api;
            Send(request);
        }

        public static void GetGasPrice(string api)
        {
            string request = ethGasRequest;
            if (api != null)
                request += api;
            Send(request);
        }

        public static void GetBlockReward(string api, string blocknum)
        {
            string request = ethGasRequest.Replace("{blocknum}", blocknum);
            if (api != null)
                request += api;
            Send(request);
        }

        public static void GetWalletBalance(string api, string address)
        {
            string request = ethGasRequest.Replace("{address}", address);
            if (api != null)
                request += api;
            Send(request);
        }
    }
}
