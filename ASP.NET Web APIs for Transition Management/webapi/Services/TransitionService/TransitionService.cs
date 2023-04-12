namespace webapi.Services.TransitionService
{
    public class TransitionService : ITransitionService
    {
        /*
        private static List<Transition> transitions = new List<Transition>
        {
            new Transition{ id=1, name="t1", description="desc", owner="o1", co_owner="co1", is_active=true, start_date=new DateOnly(2022, 3, 23), end_date=new DateOnly(2023, 3, 23), applications=new List<int>(), employees=new List<int>() },
            new Transition{ id=2, name="t2", description="desc", owner="o2", co_owner="co2", is_active=true, start_date=new DateOnly(2022, 11, 8), end_date=new DateOnly(2023, 11, 8), applications=new List<int>(), employees=new List<int>() },
            new Transition{ id=3, name="t3", description="desc", owner="o3", co_owner="co3", is_active=true, start_date=new DateOnly(2022, 7, 15), end_date=new DateOnly(2023, 7, 15), applications=new List<int>(), employees=new List<int>() }
        };
        private static List<Transition> transitions = new List<Transition>
        {
            new Transition{ Id=1, name="t1", description="desc", owner="o1", co_owner="co1", is_active=true},
            new Transition{ Id=2, name="t2", description="desc", owner="o2", co_owner="co2", is_active=true},
            new Transition{ Id=3, name="t3", description="desc", owner="o3", co_owner="co3", is_active=true}
        };
        */

        private readonly DataContext _context;

        public TransitionService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Transition>> AddTransition(Transition transition)
        {
            _context.Transitions.Add(transition);
            await _context.SaveChangesAsync();
            //transitions.Add(transition);
            return await _context.Transitions.ToListAsync();
        }

        public async Task<List<Transition>?> DeleteTransition(int Id)
        {
            var transition = await _context.Transitions.FindAsync(Id); 
            //transitions.Find(x => x.Id == Id);
            if (transition is null)
                return null;
            _context.Transitions.Remove(transition);
            await _context.SaveChangesAsync();
            //transitions.Remove(transition);
            return await _context.Transitions.ToListAsync();
        }

        public async Task<List<Transition>> GetAllTransitions()
        {
            var transitions = await _context.Transitions.ToListAsync();
            return transitions;
        }

        public async Task<Transition?> GetSingleTransition(int Id)
        {
            var transition = await _context.Transitions.FindAsync(Id);
            if (transition is null)
                return null;
            return transition;
        }

        public async Task<List<Transition>?> UpdateTransition(Transition req_transition)
        {
            var transition = await _context.Transitions.FindAsync(req_transition.Id);
            //transitions.Find(x => x.Id == req_transition.Id);
            if (transition is null)
                return null;

            transition.Id = req_transition.Id;
            transition.name = req_transition.name;
            transition.description = req_transition.description;
            transition.owner = req_transition.owner;
            transition.co_owner = req_transition.co_owner;
            transition.is_active = req_transition.is_active;
            transition.start_date = req_transition.start_date;
            transition.end_date = req_transition.end_date;
            //transition.applications = req_transition.applications;
            //transition.employees = req_transition.employees;

            await _context.SaveChangesAsync();

            return await _context.Transitions.ToListAsync();
        }
    }
}
