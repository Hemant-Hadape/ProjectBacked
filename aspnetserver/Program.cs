using aspnetserver.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPOLICY",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000");
        });
});
//builder.Services.AddMvc();
builder.Services.AddDbContext<KanbanContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"));
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerGenOptions => 
{
    SwaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP TUTORIAL", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET React Tutorial";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving a very simple Post model.");
    swaggerUIOptions.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseCors("CORSPOLICY");

//app.MapGet("/get-all-post", async () => await KanbanRepo.GetPostsAsync())
//    .WithTags("Posts Endpoints");
//app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
//{
//    Post postToReturn = await KanbanRepo.GetPostByIdAsync(postId);

//    if (postToReturn != null)
//    {
//        return Results.Ok(postToReturn);
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");

//app.MapPost("/create-post", async (Post postToCreate) =>
//{
//    bool createSuccessful = await KanbanRepo.CreatePostsAsync(postToCreate);

//    if (createSuccessful)
//    {
//        return Results.Ok("Create successful.");
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");

//app.MapPut("/update-post", async (Post postToUpdate) =>
//{
//    bool updateSuccessful = await KanbanRepo.UpdatePostAsync(postToUpdate);

//    if (updateSuccessful)
//    {
//        return Results.Ok("Update successful.");
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");

//app.MapDelete("/delete-post-by-id/{postId}", async (int postId) =>
//{
//    bool deleteSuccessful = await KanbanRepo.DeletePostAsync(postId);

//    if (deleteSuccessful)
//    {
//        return Results.Ok("Delete successful.");
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");


//amol added code


app.MapGet("/get-all-project", async () => await KanbanRepo.GetProjectAsync())
    .WithTags("Project Endpoints");
app.MapGet("/get-project-by-id/{projectId}", async (int projectId) =>
{
    Project postToReturn = await KanbanRepo.GetProjectByIdAsync(projectId);

    if (postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");

app.MapPost("/create-project", async (Project projectToCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateProjectAsync(projectToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");

app.MapPut("/update-project", async (Project projectToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateProjectAsync(projectToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");

app.MapDelete("/delete-project-by-id/{projectId}", async (int projectId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteProjectAsync(projectId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");


//-------------------------------------User end  endpoints-------------------
app.MapGet("/get-all-users", async () => await KanbanRepo.GetUserAsync())
    .WithTags("User Endpoints");
app.MapGet("/get-user-by-id/{userId}", async (int userId) =>
{
    User userToReturn = await KanbanRepo.GetUserByIdAsync(userId);

    if (userToReturn != null)
    {
        return Results.Ok(userToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");

app.MapPost("/createUser", async (User userToCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateUserAsync(userToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful!");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");

app.MapPut("/update-user", async (User userToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateUserAsync(userToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");

app.MapDelete("/delete-User-by-id/{projectId}", async (int userId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteUserAsync(userId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");
//------------------------------------Task end Point-----------------------------------------
app.MapGet("/getAllTask", async () => await KanbanRepo.GetTaskAsync())
    .WithTags("Task Endpoints");
app.MapGet("/get-task-by-id/{taskId}", async (int TaskId) =>
{
    KanbanTask taskToReturn = await KanbanRepo.GettaskByIdAsync(TaskId);

    if (taskToReturn != null)
    {
        return Results.Ok(taskToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");

app.MapPost("/create-Task", async (KanbanTask taskToCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateTaskAsync(taskToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");

app.MapPost("/updateTask", async (KanbanTask taskToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdatetaskAsync(taskToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");

app.MapPost("/deleteTaskById", async (int tskId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteTaskAsync(tskId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");
//------------------------------------status end Point-----------------------------------------
app.MapGet("/get-all-status", async () => await KanbanRepo.GetStatusAsync())
    .WithTags("status Endpoints");
app.MapGet("/get-status-by-id/{statusId}", async (int statusId) =>
{
    Status statusToReturn = await KanbanRepo.GetStatusByIdAsync(statusId);

    if (statusToReturn != null)
    {
        return Results.Ok(statusToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");

app.MapPost("/create-status", async (Status statusCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateStatusAsync(statusCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");

app.MapPut("/update-status", async (Status statusToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateStatusAsync(statusToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");

app.MapDelete("/delete-status-by-id/{statusId}", async (int statusId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteStatusAsync(statusId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");
//------------------------------------Project Member end Point-----------------------------------------
app.MapGet("/get-all-project member", async () => await KanbanRepo.GetProjectMemberAsync())
    .WithTags("Project Member Data Endpoints");
app.MapGet("/get-project member -by-id/{statusId}", async (int promemberId) =>
{
    ProjectMembers proMemToReturn = await KanbanRepo.GetProjectMemberByIdAsync(promemberId);

    if (proMemToReturn != null)
    {
        return Results.Ok(proMemToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");

app.MapPost("/create-project Member", async (ProjectMembers PmCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateProjectMembersAsync(PmCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");

app.MapPut("/update-project member", async (ProjectMembers pmToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateprojectMemberAsync(pmToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");

app.MapDelete("/delete-project member-by-id/{project memberId}", async (int projectMember) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteProjectMemberAsync(projectMember);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");
//------------------------------------status end Point-----------------------------------------
app.MapPost("/loginCheck", async (Login loginobj) =>
{
    User loginSuccessful = await KanbanRepo.LoginValidateAsync(loginobj);

    if (loginSuccessful!=null)
    {
        List<User> luser = new List<User>();
        luser.Add(loginSuccessful);

        return Results.Json(luser);
        //return Results.Ok("login successful.");
    }
    else
    {
        return Results.NotFound();
    }
}).WithTags("Login");
app.Run();
