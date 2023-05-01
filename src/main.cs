using System;
using System.IO;
using System.Text;

namespace DBTC
{
    class DBCT
    {
        static void Main(string[] args)
        {
            const string LogoText = "Discord Bot Template Creator!";
            const string ChangeLangText = "- Choose your language! -";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("\n\n\n");

            Console.SetCursorPosition((Console.WindowWidth - LogoText.Length) / 2, Console.CursorTop);
            Console.WriteLine(LogoText);
            Console.SetCursorPosition((Console.WindowWidth - ChangeLangText.Length) / 2, Console.CursorTop);
            Console.WriteLine(ChangeLangText);

            Console.WriteLine("\n\n");

            const string LanguageText = "[1] - Pycord     |     [2] - Discord.js";

            Console.SetCursorPosition((Console.WindowWidth - LanguageText.Length) / 2, Console.CursorTop);
            Console.WriteLine(LanguageText);
            Console.Write("- ");

            ConsoleKey Language = Console.ReadKey().Key;

            Console.WriteLine("\n\n");

            Console.WriteLine("Which directory?");
            Console.Write("- ");

            string DirectoryTemplate = Console.ReadLine();

            if (!Directory.Exists("templates/" + DirectoryTemplate))
            {
                Directory.CreateDirectory("templates/" + DirectoryTemplate);
            }

            string LanguageReturnText = "";
            string CreatedFileDir = "";

            if (Language == ConsoleKey.D1)
            {
                LanguageReturnText = "Pycord";
                CreatedFileDir = "templates/" + DirectoryTemplate + "/main.py";
                FileStream CreatedFile = File.Create(CreatedFileDir);
                
                string data = @"

#
#
#
#                   FuryForever's Github:
#               https://github.com/Furyforev3r
#                   Follow for More!
#
#
#                   FuryForeve's Twitter:
#               https://twitter.com/furyforev3r
# 
#
#
#                       Ty <3
#                         :D
#
#


import discord
from discord import Option
from discord.ui import Button, View, Select
import discord
from discord.ext import tasks, commands

intents = discord.Intents.all()
discord.message_content = True

bot = commands.Bot(command_prefix=['$'], intents=intents, help_command=None)


@bot.event
async def on_ready():
    print(f'Bot is ready')
    print('Bot ID: {}'.format(bot.user.id))
    await bot.change_presence(status=discord.Status.online, activity=discord.Game(name='https://github.com/FuryForev3r'))


@bot.slash_command(name='ping', description='Pong!')
async def ping_slash(ctx):
    latency = bot.latency * 1000
    await ctx.respond(f'✔ | Pong! Latency: {latency:.2f}ms')


@bot.command()
async def ping(ctx):
    latency = bot.latency * 1000
    await ctx.reply(f'✔ | Pong! Latency: {latency:.2f}ms')


token = 'TOKEN HERE'
bot.run(token)

";
                byte[] bytes = Encoding.UTF8.GetBytes(data);

                CreatedFile.Write(bytes, 0, bytes.Length);
            }

            if (Language == ConsoleKey.D2)
            {
                LanguageReturnText = "Discord.js";
                CreatedFileDir = "templates/" + DirectoryTemplate + "/index.js";
                FileStream CreatedFile = File.Create(CreatedFileDir);
                
                string data = @"
//
//
//                   FuryForever's Github:
//               https://github.com/Furyforev3r
//                   Follow for More!
//
//
//                   FuryForeve's Twitter:
//               https://twitter.com/furyforev3r
// 
//
//
//                       Ty <3
//                         :D


const Discord = require('discord.js');
const { SlashCommandBuilder } = require('@discordjs/builders');
const { REST } = require('@discordjs/rest');
const { Routes } = require('discord-api-types/v9');

const intents = new Discord.Intents();
intents.add(Discord.Intents.ALL);

const client = new Discord.Client({ intents: intents });

client.once('ready', () => {
  console.log(`Logged in as ${client.user.tag}!`);
  client.user.setActivity('https://github.com/FuryForev3r', { type: 'PLAYING' });
});

client.on('interactionCreate', async interaction => {
  if (!interaction.isCommand()) return;

  const { commandName } = interaction;

  if (commandName === 'ping') {
    const latency = client.ws.ping;
    await interaction.reply(`✔ | Pong! Latency: ${latency}ms`);
  }
});

const token = 'TOKEN HERE';
client.login(token);

";
                byte[] bytes = Encoding.UTF8.GetBytes(data);

                CreatedFile.Write(bytes, 0, bytes.Length);
            }

            Console.SetCursorPosition((Console.WindowWidth - LanguageText.Length) / 2, Console.CursorTop);
            Console.WriteLine("Creating a template in " + LanguageReturnText + "...");
            Console.WriteLine("- Success!");

            Console.ReadKey();
        }
    }
}
