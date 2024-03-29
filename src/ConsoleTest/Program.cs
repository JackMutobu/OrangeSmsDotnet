﻿using DotnetOrangeSms;
using DotnetOrangeSms.Extensions;
using DotnetOrangeSms.Models;
using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Authentication
                var smsClient = await SmsClient.Authenticate("{{authorization_header}}");
                Console.WriteLine("Account authenticated");
                PrintSeparator();
                //Send an sms
                await SendingSms(smsClient);
                PrintSeparator();
                //View Balance
                await VerifyingBalance(smsClient);
                PrintSeparator();
                //View SMS Usage statistics
                await GettingStatistics(smsClient);
                PrintSeparator();
                //View purchase history
                await GetPurchaseHistory(smsClient);
                PrintSeparator();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:{ex.Message}");                
            }

            
            
        }
        private static async Task GetPurchaseHistory(SmsClient smsClient)
        {
            var pruchaseHistoryResponse = await smsClient.GetPurchaseHistory();
            if (pruchaseHistoryResponse.IsSuccess)
                Console.WriteLine($"Stats: {pruchaseHistoryResponse.Value}");
            else
                Console.WriteLine($"Failed to fecth purchase order:{pruchaseHistoryResponse.Error}");
        }

        private static async Task GettingStatistics(SmsClient smsClient)
        {
            var statisticsResponse = await smsClient.GetStatistics();
            if (statisticsResponse.IsSuccess)
                Console.WriteLine($"Stats: {statisticsResponse.Value}");
            else
                Console.WriteLine($"Failed to fecth statistics:{statisticsResponse.Error}");
        }

        private static async Task VerifyingBalance(SmsClient smsClient)
        {
            var balanceResponse = await smsClient.VueBalance();
            if (balanceResponse.IsSuccess)
                Console.WriteLine($"Balance: {balanceResponse.Value}");
            else
                Console.WriteLine($"Failed to fecth balance:{balanceResponse.Error}");
        }

        private static async Task SendingSms(SmsClient smsClient)
        {
            var response = await smsClient.SendSms("Test", "243808790260", "243998954037", "Mandal");
            if (response.IsSuccess)
                Console.WriteLine($"Sms sent: {response.Value}");
            else
                Console.WriteLine($"Sending sms failed:{response.Error}");
        }

        private static void PrintSeparator()
        {
            Console.WriteLine($"{Environment.NewLine}********************************************************************************************{Environment.NewLine}");
        }

    }
}
