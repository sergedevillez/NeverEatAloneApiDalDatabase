﻿using NeverEatAlone.Models.Common.Interfaces;
using NeverEatAlone.Models.Global.Entities;
using NeverEatAlone.Models.Global.Repositories.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Connection;

namespace NeverEatAlone.Models.Global.Repositories
{
    public class MeetingRepository : IMeetingRepository<Meeting>
    {
        private readonly IConnection _connection;
        public MeetingRepository(IConnection connection)
        {
            _connection = connection;
        }

        public void Delete(int id)
        {
            Command command = new Command("Delete", true);
            command.AddParameter("MeetingId", id);

            //TODO: Add the userId to check if user has the correct role link to this meeting allowing him to delete it.
            _connection.ExecuteNonQuery(command);
        }

        public Meeting getById(int id)
        {
            Command command = new Command("GetMeeting", true);
            command.AddParameter("MeetingId", id);

            //TODO: check if ExecuteScalar isn't better.
            return _connection.ExecuteReader(command, dataReader => dataReader.ToMeeting()).SingleOrDefault();
        }

        public IEnumerable<Meeting> getAll()
        {
            Command command = new Command("GetAllMeetings", true);
            return _connection.ExecuteReader(command, dataReader => dataReader.ToMeeting());
        }


        public void Update(Meeting entity)
        {
            Command command = new Command("UpdateMeeting", true);
            command.AddParameter("MeetingId", entity.MeetingId);
            command.AddParameter("MeetingDateTime", entity.MeetingDateTime);
            command.AddParameter("MeetingPlace", entity.MeetingPlace);

            _connection.ExecuteNonQuery(command);
        }
    }
}