using Microsoft.AspNetCore.Mvc;
using webapi.Services.TransitionService;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransitionController : ControllerBase
    {

        private readonly ITransitionService _transitionService;

        public TransitionController(ITransitionService transitionService)
        {
            _transitionService = transitionService;
        }
        /*
        private static List<Transition> transitions = new List<Transition>
        {
            new Transition{ id=1, name="t1", description="desc", owner="o1", co_owner="co1", is_active=true, start_date=new DateOnly(2022, 3, 23), end_date=new DateOnly(2023, 3, 23), applications=new List<int>(), employees=new List<int>() },
            new Transition{ id=2, name="t2", description="desc", owner="o2", co_owner="co2", is_active=true, start_date=new DateOnly(2022, 11, 8), end_date=new DateOnly(2023, 11, 8), applications=new List<int>(), employees=new List<int>() },
            new Transition{ id=3, name="t3", description="desc", owner="o3", co_owner="co3", is_active=true, start_date=new DateOnly(2022, 7, 15), end_date=new DateOnly(2023, 7, 15), applications=new List<int>(), employees=new List<int>() }
        };
        */

        // Ok method returns a HTTP 200 OK status code along with a response body to indicate that a request has been processed successfully
        // 

        [HttpGet]
        public async Task<ActionResult<List<Transition>>> GetAllTransitions()
        {
            var transitions = await _transitionService.GetAllTransitions();
            return Ok(transitions);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<Transition>> GetSingleTransition(int Id)
        {
            var transition = await _transitionService.GetSingleTransition(Id);
            if (transition is null)
                return NotFound("The requested transition doesn't exist!");
            return Ok(transition);
        }

        [HttpPost]
        //public async Task<ActionResult<List<Transition>>> AddTransition(Transition transition)
        public async Task<ActionResult<List<Transition>>> AddTransition([FromBody] Transition transition)
        {
            var result = await _transitionService.AddTransition(transition);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Transition>>> UpdateTransition([FromBody] Transition req_transition)
        {
            var transitions = await _transitionService.UpdateTransition(req_transition);
            if (transitions is null)
                return NotFound("The requested hero doesn't exist!");
            return Ok(transitions);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Transition>>> DeleteTransition(int Id)
        {
            var transitions = await _transitionService.DeleteTransition(Id);
            if (transitions is null)
                return NotFound("The requested transition doesn't exist!");
            return Ok(transitions);
        }
    }
}
