using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuestlineBot {

    public class QuestlineBot {

        private Telegram.Bot.TelegramBotClient botClient;

        public QuestlineBot() {
            botClient = new Telegram.Bot.TelegramBotClient("554478923:AAFoXsqMvvoZvEKfePjdT1dCrP4C1BkjdRE");

            botClient.OnMessage += MessageReceived;
        }

        public void Start() {

            botClient.StartReceiving();

            while (true) {
                
            }
        }

        private async void MessageReceived(object sender, EventArgs args) {
            var message = (Telegram.Bot.Args.MessageEventArgs)args;

            Console.WriteLine(string.Format("Message received from {0}:", message.Message.From));

            if (bool.Parse(ConfigurationManager.AppSettings["DeveloperMode"]) )
                return;

            ReplyKeyboardMarkup battleMenuMarkup = new[] {
                new[] { "⚔️ Attack ⚔️",   "🔮 Magic 🔮"  },
                new[] { "✨ Skill ✨", "🎒 Item 🎒" }
            };

            battleMenuMarkup.ResizeKeyboard = true;

            await botClient.SendTextMessageAsync(
                chatId: message.Message.Chat.Id,
                text: "Choose an action.",
                replyMarkup: battleMenuMarkup
            );
        }
    }
}
