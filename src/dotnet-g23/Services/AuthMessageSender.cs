﻿using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.IO;
using System.Diagnostics;

namespace dotnet_g23.Services {
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender {
        public AuthMessageSender() {

        }
        public async void SendEmail(string receiver, string email, string organizationName, string beschrijving) {
            // Plug in your email service here to send an email.
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Goed Bezig!", "goedbezig-g23@outlook.com"));
            emailMessage.To.Add(new MailboxAddress(receiver, email));
            emailMessage.Subject = "Uitreiking Goed Bezig!-label voor " + receiver + ".";

            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText("App_data/Template/EmailTemplate.html")) {
                builder.HtmlBody = SourceReader.ReadToEnd();
                builder.HtmlBody = builder.HtmlBody.Replace("{organization}", organizationName).Replace("{company}", receiver).Replace("{description}", beschrijving);
            }

            var multipart = new Multipart("mixed");
            multipart.Add(new TextPart("html"));

            emailMessage.Body = builder.ToMessageBody();

            //emailMessage.Body = new TextPart("plain") { Text = @"Test" };

            using (var client = new SmtpClient()) {
                client.Connect("smtp-mail.outlook.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                //client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("goedbezig-g23@outlook.com", "AUnws8ClDrVAN7ui6wP55g80LxgZ1DU1jgFA5dDPFY25oapScj");

                await client.SendAsync(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}