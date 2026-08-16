using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses;
public class ResponseShortTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public DateTime dueDate { get; set; }
    public Status Status { get; set; }
}