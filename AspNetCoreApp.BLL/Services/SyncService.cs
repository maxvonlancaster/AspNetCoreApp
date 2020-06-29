using AspNetCoreApp.BLL.Const;
using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AspNetCoreApp.BLL.Services
{
    public class SyncService: IHostedService, IDisposable
    {
        IServiceScopeFactory _serviceScopeFactory;
        private readonly TelegramBotClient _client;

        public SyncService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _client = new TelegramBotClient(Secrets.TelegramToken);
        }

        public void Dispose()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _client.OnMessage += OnFirstMessage;
            _client.OnCallbackQuery += OnCallBack;

            Thread th = new Thread(new ThreadStart(() =>
            {
                _client.StartReceiving(cancellationToken: cancellationToken);
                Console.WriteLine("Started Receiving");
                while (!cancellationToken.IsCancellationRequested)
                {
                    _client.GetUpdatesAsync();
                }
            }));

            th.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnCallBack(object sender, CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void OnFirstMessage(object sender, MessageEventArgs e)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                IUserService userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                User user = await userService.GetByTelegramId(e.Message.From.Username);
            }
        }
    }
}
