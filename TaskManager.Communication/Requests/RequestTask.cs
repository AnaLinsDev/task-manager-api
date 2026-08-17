using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Requests;
public class RequestTask
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime dueDate { get; set; }
    public Status Status { get; set; }
}
