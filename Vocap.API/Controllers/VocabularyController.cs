﻿using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Vocap.API.Application.Commands;
using Vocap.API.Application.Queries;
using Vocap.API.RabbitMessage;
using Vocap.API.RabbitMQSender;

namespace Vocap.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VocabularyController : ControllerBase
    {
        private IMediator mediator;
        private IVocabularyQueries queries;
        private readonly IRabbitMQMessageSender rabbitMQMessageSender;
        public VocabularyController(IMediator mediator, IVocabularyQueries queries, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            this.mediator = mediator;
            this.queries = queries;
            this.rabbitMQMessageSender = rabbitMQMessageSender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewVocap([FromBody] CreateVocabularyRequest request)
        {
            var createdCommand = new CreateVocabularyCommand
                (desc: request.Desc, name: request.Name);
            await mediator.Send(createdCommand);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetVocabulary([FromQuery] string word)
        {
            var values = await queries.GetVocabularyAsync(word);
            return Ok(values);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string word)
        {
            var values = await queries.SearchWork(word);
            return Ok(values);

        }

        [HttpGet("push")]
        public async Task<IActionResult> CreateMessage(string mesage)
        {
            var message = new PaymentMessage();
            message.Name = mesage; ;
            message.CardNumber = "123123123";
            rabbitMQMessageSender.SendMessageAsync(message, "sla_queue");
            return Ok();
        }
    }
}
public record CreateVocabularyRequest(
    string Name, string Desc);