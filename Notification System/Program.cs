using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Notification_System {
    //{2- Notification System:
    //-Create a NotificationSystem class with a delegate for sending notifications.
    //-Implement methods for sending notifications via email, SMS, and push notification.
    //-Subscribers can choose to receive notifications through different channels.
    public class Message
    {
        public string messageSender;
        public string messageContent;
        public Message(string sender, string Content)
        {
            this.messageSender = sender;
            this.messageContent = Content;
        }

    }
    public class Notifier
    {
        public delegate int NotifyAction(string message);
        private NotifyAction notify;
        public Notifier(NotifyAction c)
        {
            notify = c;
        }
        public int Notification(string message)
        {
            return notify(message);
        }

    }
  
    public class Subscriber
    {
        public void Subsribe(Notifier notifier)
        {
            notifier.Notification += HandleNotification;

        }

        public void UnSubsribe() {
            notifier.Notification -= HandleNotification;

        }
        public void HandleNotification(object sender, Message message)
        {

            Console.WriteLine($" {message.messageSender} send message to you");
            Console.WriteLine($"Content : {message.messageContent} ");

        }
    }


   
    internal class Program
    {
        public static void SMS(string message)
        {
            Console.WriteLine("sms notifications");
        }
        public static void email(string message)
        {
            Console.WriteLine("email notifications");
        }
        public static void facebook(string message)
        {
            Console.WriteLine("facebook notifications");
        }
     
        static void Main(string[] args)
        {
        }
    }
}
