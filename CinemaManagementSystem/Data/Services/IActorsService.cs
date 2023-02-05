using CinemaManagementSystem.Models;
using System.Collections;
using System.Collections.Generic;

namespace CinemaManagementSystem.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        Actor Update(int id, Actor newActor);
        void Delete(int id);
    }
}
