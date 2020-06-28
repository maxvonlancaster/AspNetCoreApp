using AspNetCoreApp.BLL.Const;
using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AspNetCoreApp.BLL.Services
{
    public class SyncService: ISyncService
    {
        private readonly IUserService _userService;
        private readonly IPresentationService _presentationService;
        private readonly TelegramBotClient _client;

        public SyncService(IUserService userService, IPresentationService presentationService)
        {
            _userService = userService;
            _presentationService = presentationService;
            _client = new TelegramBotClient(Secrets.TelegramToken);
            StartReceiving();
        }

        public void StartReceiving() 
        {
            var cts = new CancellationTokenSource();
            var stoppingToken = cts.Token;

            _client.OnMessage += OnFirstMessage;
            _client.OnCallbackQuery += OnCallBack;

            Task.Run(() =>
            {
                _client.StartReceiving(cancellationToken: stoppingToken);
                Console.WriteLine("Started Receiving");
                while (!stoppingToken.IsCancellationRequested)
                {
                    _client.GetUpdatesAsync();
                }
            });
        }

        private void OnCallBack(object sender, CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void OnFirstMessage(object sender, MessageEventArgs e)
        {
            User user = await _userService.GetByTelegramId(e.Message.From.Username);
            throw new NotImplementedException();
        }
    }
}
