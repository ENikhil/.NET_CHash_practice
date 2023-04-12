namespace webapi.Services.TransitionService
{
    public interface ITransitionService
    {
        //Task is a type for asynchronous operations and ? is added after the data type of the returnable result to show the possiblity of a null result
        Task<List<Transition>> GetAllTransitions();

        Task<Transition?> GetSingleTransition(int Id);

        Task<List<Transition>> AddTransition(Transition transition);

        Task<List<Transition>?> UpdateTransition(Transition transition);

        Task<List<Transition>?> DeleteTransition(int Id);
    }
}
