using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Assignment7.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addworkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    WorkflowId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkflowName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.WorkflowId);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowSequence",
                columns: table => new
                {
                    StepId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkflowId = table.Column<int>(type: "integer", nullable: false),
                    StepName = table.Column<string>(type: "text", nullable: true),
                    StepOrder = table.Column<int>(type: "integer", nullable: false),
                    RequiredRoleId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowSequence", x => x.StepId);
                    table.ForeignKey(
                        name: "FK_WorkflowSequence_AspNetRoles_RequiredRoleId",
                        column: x => x.RequiredRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowSequence_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "WorkflowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextStepRule",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrentStepId = table.Column<int>(type: "integer", nullable: false),
                    NextStepId = table.Column<int>(type: "integer", nullable: false),
                    ConditionType = table.Column<string>(type: "text", nullable: true),
                    ConditionValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextStepRule", x => x.RuleId);
                    table.ForeignKey(
                        name: "FK_NextStepRule_WorkflowSequence_CurrentStepId",
                        column: x => x.CurrentStepId,
                        principalTable: "WorkflowSequence",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NextStepRule_WorkflowSequence_NextStepId",
                        column: x => x.NextStepId,
                        principalTable: "WorkflowSequence",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    ProcessId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkflowId = table.Column<int>(type: "integer", nullable: false),
                    RequesterId = table.Column<string>(type: "text", nullable: true),
                    RequestType = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    CurrentStepId = table.Column<int>(type: "integer", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.ProcessId);
                    table.ForeignKey(
                        name: "FK_Process_AspNetUsers_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Process_NextStepRule_CurrentStepId",
                        column: x => x.CurrentStepId,
                        principalTable: "NextStepRule",
                        principalColumn: "RuleId");
                    table.ForeignKey(
                        name: "FK_Process_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "WorkflowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    ProcessId = table.Column<int>(type: "integer", nullable: false),
                    BookTitle = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    Publisher = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequest", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_BookRequest_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookRequest_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Process",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowAction",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProcessId = table.Column<int>(type: "integer", nullable: false),
                    StepId = table.Column<int>(type: "integer", nullable: false),
                    ActorId = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowAction", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_WorkflowAction_AspNetUsers_ActorId",
                        column: x => x.ActorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowAction_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Process",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowAction_WorkflowSequence_StepId",
                        column: x => x.StepId,
                        principalTable: "WorkflowSequence",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequest_AppUserId",
                table: "BookRequest",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequest_ProcessId",
                table: "BookRequest",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_NextStepRule_CurrentStepId",
                table: "NextStepRule",
                column: "CurrentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_NextStepRule_NextStepId",
                table: "NextStepRule",
                column: "NextStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_CurrentStepId",
                table: "Process",
                column: "CurrentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_RequesterId",
                table: "Process",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_WorkflowId",
                table: "Process",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_ActorId",
                table: "WorkflowAction",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_ProcessId",
                table: "WorkflowAction",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_StepId",
                table: "WorkflowAction",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowSequence_RequiredRoleId",
                table: "WorkflowSequence",
                column: "RequiredRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowSequence_WorkflowId",
                table: "WorkflowSequence",
                column: "WorkflowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequest");

            migrationBuilder.DropTable(
                name: "WorkflowAction");

            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "NextStepRule");

            migrationBuilder.DropTable(
                name: "WorkflowSequence");

            migrationBuilder.DropTable(
                name: "Workflow");
        }
    }
}
