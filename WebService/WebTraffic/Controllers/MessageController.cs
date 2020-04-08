using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService;
using WebTraffic.Models;

namespace WebTraffic.Controllers
{
    public class MessageController : ApiController
    {
        MessageModel messageModelFactory;
        public MessageController()
        {
            messageModelFactory = new MessageModel();
        }

        /*public IEnumerable<Uzenet> Get()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetAllMessage().ToList().Select(s => new Uzenet
            {
                /*uzenetId = s.uzenetId,
                soforId = s.soforId,
                vonalId = s.vonalId,
                buszId = s.buszId,
                datum = s.datum,
                lat = s.lat,
                lon = s.lon,
                jelzesId = s.jelzesId
                MessageId = x.uzenetId,
                MessageTypeId = x.Jelze.jelzesId,
                MessageTypeName = x.Jelze.jelzesNev,
                DriverName = x.Sofor.soforNev,
                DriverId = x.Sofor.soforId,
                Line = x.Vonal.vonalId,
                Bus = x.Busz.buszId,
                MessageDate = x.datum.Value,
                MessageLon = x.lat.Value,
                MessageLat = x.lon.Value
            });
        }

        public IHttpActionResult GetMessages()
        {
            IList<MessageModel> messages =null;
            //MessageModel messages = null;
            using (var ctx = new trafficEntities())
            {
                messages = ctx.Uzenets
                    .Select(s => new MessageModel()
                    {
                        MessageId = s.uzenetId,
                        MessageTypeId = s.Jelze.jelzesId,
                        MessageTypeName = s.Jelze.jelzesNev,
                        DriverId =(int) s.soforId.Value,
                        DriverName = s.Sofor.soforNev,
                        Line = s.vonalId.Value,
                        Bus = s.buszId.Value,
                        MessageDate = s.datum.Value,
                        MessageLat = s.lat.Value,
                        MessageLon = s.lon.Value
                    }).ToList<MessageModel>();
            }

            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        public IHttpActionResult GetLines(int line)
        {
            //MessageModel lines = null;
            IList<MessageModel> lines = null;
            using (var ctx = new trafficEntities())
            {
                lines = ctx.Uzenets
                    .Where(s => s.vonalId == line)
                    .Select(s => new MessageModel()
                    {
                        MessageId = s.uzenetId,
                        MessageTypeId = s.Jelze.jelzesId,
                        MessageTypeName = s.Jelze.jelzesNev,
                        DriverId = s.Sofor.soforId,
                        DriverName = s.Sofor.soforNev,
                        Line = s.Vonal.vonalId,
                        Bus = s.Busz.buszId,
                        MessageDate = s.datum.Value,
                        MessageLat = s.lat.Value,
                        MessageLon = s.lon.Value
                    }).ToList<MessageModel>();
            }

            if (lines == null)
            {
                return NotFound();
            }

            return Ok(lines);
        }*/
        
        [HttpPost]
        public void Post([FromBody] Uzenet newMessage)
        {
            using (trafficEntities db = new trafficEntities())
            {
                db.Uzenets.Add(newMessage);
                db.SaveChanges();
            }
        }
    }
}
