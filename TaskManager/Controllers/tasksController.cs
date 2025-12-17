using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Repository;
using TaskManager.DTO;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public tasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }



        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Entities.Task>> Post([FromBody] TaskInsertDto taskInsertDto)
        {
            var task = _mapper.Map<Entities.Task>(taskInsertDto);
            var newrecord = await _taskRepository.AddTask(task); 

            return Created($"api/tasks/{task.Id}",newrecord);
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            var listataskDto = new List<TaskDto>();
            foreach (var task in tasks)
            {
                listataskDto.Add(_mapper.Map<TaskDto>(task));
            }
            return Ok(listataskDto);
        }

        [HttpGet("{taskId:int}", Name = "GetTaskById")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaskDto>> GetTaskById(int taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);

            if (task is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskDto>(task));
        }


        [HttpPut("{taskId:int}", Name = "Put")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status403Forbidden)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromBody] TaskUpdateDto taskUpdateDto, int taskId)
        {

            var task = await _taskRepository.GetTaskById(taskId);

            if (task is null)
            {
                return NotFound();
            }

            task.Title = String.IsNullOrEmpty(taskUpdateDto.Title) ? task.Title : taskUpdateDto.Title;
            task.Description = String.IsNullOrEmpty(taskUpdateDto.Description) ? task.Description : taskUpdateDto.Description;
            task.Status = taskUpdateDto.Status;

            await _taskRepository.UpdateTask(task);

            return Ok();

        }


        [HttpDelete("{taskId:int}", Name = "Delete")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status403Forbidden)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int taskId)
        {

            var task = await _taskRepository.GetTaskById(taskId);

            if (task is null)
            {
                return NotFound();
            }

            await _taskRepository.DeleteTask(task);

            return Ok();

        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {                                            // Middleware funcionando!!
            throw new Exception("Error de prueba!!");  //captura excepciones no controladas asi que este mensaje nunca aparece
                                                       // en la respuesta entregada, aparecera un "500 Error interno del servidor".
        }
    }
}
