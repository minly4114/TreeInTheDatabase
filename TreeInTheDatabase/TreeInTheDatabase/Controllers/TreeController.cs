using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreeInTheDatabase.IProviders;
using TreeInTheDatabase.Models;

namespace TreeInTheDatabase.Controllers
{
    [Route("api/v1/tree")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly INodesProvider _nodesProvider;
        public TreeController(INodesProvider nodesProvider)
        {
            _nodesProvider = nodesProvider;
        }

        /// <summary>
        /// Получает все узлы
        /// </summary>
        /// <returns>Запрошенные узлы</returns>
        /// <response code="200">Успешная операция</response>
        /// <response code="400">Ошибка запроса</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult GetNode()
        {
            var nodes = _nodesProvider.GetNodes().Where(x => x.Parent == null).Include(x => x.Children).ToList();
            nodes.ForEach(x => x = GetChildren(x));
            return StatusCode(200, nodes);
        }
        private Node GetChildren(Node node)
        {
            var nodedb = _nodesProvider.GetNodes().Where(x => x == node).Include(x => x.Children).FirstOrDefault();
            if (nodedb!=null && nodedb.Children != null)
            {
                nodedb.Children.ForEach(x => x = GetChildren(x));
            }

            if (nodedb != null)
            {
                nodedb.Parent = null;
            }
            return nodedb;
        }
        [HttpPost("circle")]
        public async Task<ActionResult> AddCircle(Guid? parentGuid,Guid guid, double radius)
        {
            var parentNode = _nodesProvider.GetNodes().FirstOrDefault(x => x.Guid == parentGuid);
            var node = _nodesProvider.GetNodes().FirstOrDefault(x => x.Guid == guid);
            Circle circle = new Circle();
            if (parentGuid != null)
            {
                circle.Parent = parentNode;
            }
            circle.Guid = guid;
            circle.Radius = radius;
            await _nodesProvider.InsertAsync(circle.ToNode());
            return StatusCode(200);
        }
        [HttpPost("quadrate")]
        public async Task<ActionResult> AddQuadrate(Guid? parentGuid, Guid guid, double side)
        {
            var parentNode = _nodesProvider.GetNodes().FirstOrDefault(x => x.Guid == parentGuid);
            var quadrate = new Quadrate();
            if (parentGuid != null)
            {
                quadrate.Parent = parentNode;
            }
            quadrate.Guid = guid;
            quadrate.Side = side;
            await _nodesProvider.InsertAsync(quadrate.ToNode());
            return StatusCode(200);
        }
        [HttpPost("rectangle")]
        public async Task<ActionResult> AddRectangle(Guid? parentGuid, Guid guid, double firstSide, double secondSide)
        {
            var parentNode = _nodesProvider.GetNodes().FirstOrDefault(x => x.Guid == parentGuid);
            var rectangle = new Rectangle();
            if (parentGuid != null)
            {
                rectangle.Parent = parentNode;
            }
            rectangle.Guid = guid;
            rectangle.FirstSide = firstSide;
            rectangle.SecondSide = secondSide;
            await _nodesProvider.InsertAsync(rectangle.ToNode());
            return StatusCode(200);
        }
    }
}