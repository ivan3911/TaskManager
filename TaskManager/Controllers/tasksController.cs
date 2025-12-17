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
        public async Task<Entities.Task> Post(TaskInsertDto taskInsertDto)
        {
            var task = _mapper.Map<Entities.Task>(taskInsertDto);

            var newrecord = await _taskRepository.AddTask(task);
            return newrecord;
        }

        [HttpGet]
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
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);

            if (task is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskDto>(task));
        }


        [HttpPut("{taskId:int}", Name = "Put")]
        public async Task<ActionResult> Put(TaskUpdateDto taskUpdateDto, int taskId)
        {

            var task = await _taskRepository.GetTaskById(taskId);

            if (task is null)
            {
                return NotFound();
            }

            task.Title =  String.IsNullOrEmpty(taskUpdateDto.Title) ? task.Title : taskUpdateDto.Title;
            task.Description = String.IsNullOrEmpty(taskUpdateDto.Description) ? task.Description : taskUpdateDto.Description;
            task.Status = taskUpdateDto.Status;

            await _taskRepository.UpdateTask(task);

            return Ok();

        }


        [HttpDelete("{taskId:int}", Name = "Delete")]
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
    }
}
