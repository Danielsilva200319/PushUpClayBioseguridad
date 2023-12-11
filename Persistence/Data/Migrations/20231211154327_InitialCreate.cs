using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "addresstype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacttype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personcategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameCategory = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persontype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShiftName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeShiftStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    TimeShiftEnd = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "department_idcountry_foreign",
                        column: x => x.IdCountry,
                        principalTable: "country",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "city_iddepartment_foreign",
                        column: x => x.IdDepartment,
                        principalTable: "department",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReg = table.Column<DateOnly>(type: "date", nullable: false),
                    IdPersonType = table.Column<int>(type: "int", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "person_idcategory_foreign",
                        column: x => x.IdCategory,
                        principalTable: "personcategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "person_idcity_foreign",
                        column: x => x.IdCity,
                        principalTable: "city",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "person_idpersontype_foreign",
                        column: x => x.IdPersonType,
                        principalTable: "persontype",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateContract = table.Column<DateOnly>(type: "date", nullable: false),
                    DateEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "contract_idclient_foreign",
                        column: x => x.IdClient,
                        principalTable: "person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "contract_idemployee_foreign",
                        column: x => x.IdEmployee,
                        principalTable: "person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "contract_idstate_foreign",
                        column: x => x.IdState,
                        principalTable: "state",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personaddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    IdAddressType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "personaddress_idaddresstype_foreign",
                        column: x => x.IdAddressType,
                        principalTable: "addresstype",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "personaddress_idperson_foreign",
                        column: x => x.IdPerson,
                        principalTable: "person",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personcontact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    IdContactType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "personcontact_idcontacttype_foreign",
                        column: x => x.IdContactType,
                        principalTable: "contacttype",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "personcontact_idperson_foreign",
                        column: x => x.IdPerson,
                        principalTable: "person",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdContract = table.Column<int>(type: "int", nullable: false),
                    IdShifts = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "programming_idcontract_foreign",
                        column: x => x.IdContract,
                        principalTable: "contract",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "programming_idemployee_foreign",
                        column: x => x.IdEmployee,
                        principalTable: "person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "programming_idshifts_foreign",
                        column: x => x.IdShifts,
                        principalTable: "shifts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "city_iddepartment_foreign",
                table: "city",
                column: "IdDepartment");

            migrationBuilder.CreateIndex(
                name: "contract_idclient_foreign",
                table: "contract",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "contract_idemployee_foreign",
                table: "contract",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "contract_idstate_foreign",
                table: "contract",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "department_idcountry_foreign",
                table: "department",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "person_idcategory_foreign",
                table: "person",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "person_idcity_foreign",
                table: "person",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "person_idperson_unique",
                table: "person",
                column: "IdPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "person_idpersontype_foreign",
                table: "person",
                column: "IdPersonType");

            migrationBuilder.CreateIndex(
                name: "personaddress_idaddresstype_foreign",
                table: "personaddress",
                column: "IdAddressType");

            migrationBuilder.CreateIndex(
                name: "personaddress_idperson_foreign",
                table: "personaddress",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "personcontact_description_unique",
                table: "personcontact",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "personcontact_idcontacttype_foreign",
                table: "personcontact",
                column: "IdContactType");

            migrationBuilder.CreateIndex(
                name: "personcontact_idperson_foreign",
                table: "personcontact",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "programming_idcontract_foreign",
                table: "programming",
                column: "IdContract");

            migrationBuilder.CreateIndex(
                name: "programming_idemployee_foreign",
                table: "programming",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "programming_idshifts_foreign",
                table: "programming",
                column: "IdShifts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personaddress");

            migrationBuilder.DropTable(
                name: "personcontact");

            migrationBuilder.DropTable(
                name: "programming");

            migrationBuilder.DropTable(
                name: "addresstype");

            migrationBuilder.DropTable(
                name: "contacttype");

            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "shifts");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "personcategory");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "persontype");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
