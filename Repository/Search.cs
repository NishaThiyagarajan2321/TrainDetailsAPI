using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainDetailsAPI.Models;

namespace TrainDetailsAPI.Repository
{
    public class Search : ISearch
    {
        private readonly TICKET_BOOKINGContext _context;
        public Search(TICKET_BOOKINGContext context)
        {
            _context = context;
        }
        public IEnumerable<TrainDetail> GetAllTrainDetail()
        {
          
                return _context.TrainDetails.ToList();

        }

        public List<TrainDetail> SearchTrain(string from, string to)
        {
           

            List<TrainDetail> searchtrain = _context.TrainDetails.Where(tr => tr.FromStation == from && tr.ToStation == to).Select(tr=>tr).ToList<TrainDetail>();
            
            return searchtrain;
          

        }



    }
}
