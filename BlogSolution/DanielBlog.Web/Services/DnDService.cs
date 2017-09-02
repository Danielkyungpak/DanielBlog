using DanielBlog.Web.Models.Domain.DnD;
using DanielBlog.Web.Models.Requests.DnD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Services
{
    public class DnDService
    {
        //Character Detail Insert
        public int CharacterDetailsInsert(CharacterDetailsAddReq payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Character_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Class", payload.Class);
                    cmd.Parameters.AddWithValue("@Level", payload.Level);
                    cmd.Parameters.AddWithValue("@Background", payload.Background);
                    cmd.Parameters.AddWithValue("@PlayerName", payload.PlayerName);
                    cmd.Parameters.AddWithValue("@Race", payload.Race);
                    cmd.Parameters.AddWithValue("@Alignment", payload.Alignment);
                    cmd.Parameters.AddWithValue("@ExperiencePoints", payload.ExperiencePoints);


                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }

            }
            return id;

        }

        //Character Detail GetAllCharacters
        public List<CharacterDetails> GetAllCharacterDetails()
        {
            List<CharacterDetails> charList = new List<CharacterDetails>();

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int startingIndex = 0;
                        CharacterDetails c = new CharacterDetails();
                        c.Id = reader.GetInt32(startingIndex++);
                        c.Class = reader.GetString(startingIndex++);
                        c.Level = reader.GetInt32(startingIndex++);
                        c.Background = reader.GetString(startingIndex++);
                        c.PlayerName = GetSafeString(reader, startingIndex++);
                        c.Race = reader.GetString(startingIndex++);
                        c.Alignment = reader.GetString(startingIndex++);
                        c.ExperiencePoints = reader.GetInt32(startingIndex++);

                        charList.Add(c);

                    }
                }
            }
            return charList;
        }

        //Character Detail Update
        public void CharacterDetailsUpdate(CharacterDetailsUpdateReq payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@Class", payload.Class);
                    cmd.Parameters.AddWithValue("@Level", payload.Level);
                    cmd.Parameters.AddWithValue("@Background", payload.Background);
                    cmd.Parameters.AddWithValue("@PlayerName", payload.PlayerName);
                    cmd.Parameters.AddWithValue("@Race", payload.Race);
                    cmd.Parameters.AddWithValue("@Alignment", payload.Alignment);
                    cmd.Parameters.AddWithValue("@ExperiencePoints", payload.ExperiencePoints);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Character Detail GetById
        public CharacterDetails GetCharacterDetails(int id)
        {
            CharacterDetails c = new CharacterDetails();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int startingIndex = 0;
                        c.Id = reader.GetInt32(startingIndex++);
                        c.Class = reader.GetString(startingIndex++);
                        c.Level = reader.GetInt32(startingIndex++);
                        c.Background = reader.GetString(startingIndex++);
                        c.PlayerName = GetSafeString(reader, startingIndex++);
                        c.Race = reader.GetString(startingIndex++);
                        c.Alignment = reader.GetString(startingIndex++);
                        c.ExperiencePoints = reader.GetInt32(startingIndex++);
                    }
                }

            }
            return c;
        }

        //MainStats Insert
        public int MainStatsInsert(MainStatsAddReq payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.MainBaseStats_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@Strength", payload.Strength);
                    cmd.Parameters.AddWithValue("@Dexterity", payload.Dexterity);
                    cmd.Parameters.AddWithValue("@Constitution", payload.Constitution);
                    cmd.Parameters.AddWithValue("@Intelligence", payload.Intelligence);
                    cmd.Parameters.AddWithValue("@Wisdom", payload.Wisdom);
                    cmd.Parameters.AddWithValue("@Charisma", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@ProficiencyBonus", payload.ProficiencyBonus);
                    cmd.Parameters.AddWithValue("@Inspiration", payload.Inspiration);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }

            }
            return id;
        }

        //MainStats GetByCharacterId
        public MainStats MainStatsByCharId(int id)
        {
            MainStats m = new MainStats();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int startingIndex = 0;
                        m.Id = reader.GetInt32(startingIndex++);
                        m.CharacterId = reader.GetInt32(startingIndex++);
                        m.Strength = reader.GetInt32(startingIndex++);
                        m.Dexterity = reader.GetInt32(startingIndex++);
                        m.Constitution = reader.GetInt32(startingIndex++);
                        m.Intelligence = reader.GetInt32(startingIndex++);
                        m.Wisdom = reader.GetInt32(startingIndex++);
                        m.Charisma = reader.GetInt32(startingIndex++);
                        m.ProficiencyBonus = reader.GetInt32(startingIndex++);
                        m.Inspiration = reader.GetBoolean(startingIndex++);
                    }
                }

            }
            return m;
        }

        //MainStats Update
        public void MainStatsUpdate(MainStatsUpdateReq payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@Strength", payload.Strength);
                    cmd.Parameters.AddWithValue("@Dexterity", payload.Dexterity);
                    cmd.Parameters.AddWithValue("@Constitution", payload.Constitution);
                    cmd.Parameters.AddWithValue("@Intelligence", payload.Intelligence);
                    cmd.Parameters.AddWithValue("@Wisdom", payload.Wisdom);
                    cmd.Parameters.AddWithValue("@Charisma", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@ProficiencyBonus", payload.ProficiencyBonus);
                    cmd.Parameters.AddWithValue("@Inspiration", payload.Inspiration);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Health Insert
        public int HealthInsert(HealthAddReq payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Health_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@MaxHealth", payload.MaxHealth);
                    cmd.Parameters.AddWithValue("@TempHealth", payload.TempHealth);
                    cmd.Parameters.AddWithValue("@CurrentHealth", payload.CurrentHealth);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }

            }
            return id;

        }

        //Health GetByCharacterId
        public Health HealthByCharId(int id)
        {
            Health h = new Health();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int startingIndex = 0;
                        h.Id = reader.GetInt32(startingIndex++);
                        h.CharacterId = reader.GetInt32(startingIndex++);
                        h.MaxHealth = reader.GetInt32(startingIndex++);
                        h.TempHealth = reader.GetInt32(startingIndex++);
                        h.CurrentHealth = reader.GetInt32(startingIndex++);
                    }
                }
            }
            return h;
        }

        //Health Update
        public void HealthUpdate(HealthUpdateReq payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@MaxHealth", payload.MaxHealth);
                    cmd.Parameters.AddWithValue("@TempHealth", payload.TempHealth);
                    cmd.Parameters.AddWithValue("@CurrentHealth", payload.CurrentHealth);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //HitDice Insert
        public int HitDiceInsert(HitDiceAddReq payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.HitDice_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@D4", payload.D4);
                    cmd.Parameters.AddWithValue("@D6", payload.D6);
                    cmd.Parameters.AddWithValue("@D8", payload.D8);
                    cmd.Parameters.AddWithValue("@D10", payload.D10);
                    cmd.Parameters.AddWithValue("@D12", payload.D12);


                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }

            }
            return id;

        }

        //HitDice GetByCharacterId
        public HitDice HitDiceByCharId(int id)
        {
            HitDice h = new HitDice();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int startingIndex = 0;
                        h.Id = reader.GetInt32(startingIndex++);
                        h.CharacterId = reader.GetInt32(startingIndex++);
                        h.D4 = reader.GetInt32(startingIndex++);
                        h.D6 = reader.GetInt32(startingIndex++);
                        h.D8 = reader.GetInt32(startingIndex++);
                        h.D10 = reader.GetInt32(startingIndex++);
                        h.D12 = reader.GetInt32(startingIndex++);
                    }
                }

            }
            return h;
        }

        //HitDice Update
        public void HitDiceUpdate(HitDiceUpdateReq payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@D4", payload.D4);
                    cmd.Parameters.AddWithValue("@D6", payload.D6);
                    cmd.Parameters.AddWithValue("@D8", payload.D8);
                    cmd.Parameters.AddWithValue("@D10", payload.D10);
                    cmd.Parameters.AddWithValue("@D12", payload.D12);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DeathSaves Insert
        public int DeathSavesInsert(DeathSavesAddReq payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.DeathSaves_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@Successes", payload.Successes);
                    cmd.Parameters.AddWithValue("@Failures", payload.Failures);


                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }

            }
            return id;

        }

        //DeathSaves GetByCharacterId
        public DeathSaves DeathSavesByCharId(int id)
        {
            DeathSaves d = new DeathSaves();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int startingIndex = 0;
                        d.Id = reader.GetInt32(startingIndex++);
                        d.CharacterId = reader.GetInt32(startingIndex++);
                        d.Successes = reader.GetInt32(startingIndex++);
                        d.Failures = reader.GetInt32(startingIndex++);
                    }
                }

            }
            return d;
        }

        //DeathSaves Update
        public void DeathSavesUpdate(DeathSavesUpdateReq payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@Successes", payload.Successes);
                    cmd.Parameters.AddWithValue("@Failures", payload.Failures);
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Skill Value Insert
        public int PlayerSkillInsert(PlayerSkillAddReq payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.PlayerSkill_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@Acrobatics", payload.Acrobatics);
                    cmd.Parameters.AddWithValue("@AcrobaticsPro", payload.AcrobaticsPro);
                    cmd.Parameters.AddWithValue("@AnimalHandling", payload.AnimalHandling);
                    cmd.Parameters.AddWithValue("@AnimalHandlingPro", payload.AnimalHandlingPro);
                    cmd.Parameters.AddWithValue("@Arcana", payload.Arcana);
                    cmd.Parameters.AddWithValue("@ArcanaPro", payload.ArcanaPro);
                    cmd.Parameters.AddWithValue("@Athletics", payload.Athletics);
                    cmd.Parameters.AddWithValue("@AthleticsPro", payload.AthleticsPro);
                    cmd.Parameters.AddWithValue("@Deception", payload.Deception);
                    cmd.Parameters.AddWithValue("@DeceptionPro", payload.DeceptionPro);
                    cmd.Parameters.AddWithValue("@History", payload.History);
                    cmd.Parameters.AddWithValue("@HistoryPro", payload.HistoryPro);
                    cmd.Parameters.AddWithValue("@Insight", payload.Insight);
                    cmd.Parameters.AddWithValue("@InsightPro", payload.InsightPro);
                    cmd.Parameters.AddWithValue("@Intimidation", payload.Intimidation);
                    cmd.Parameters.AddWithValue("@IntimidationPro", payload.IntimidationPro);
                    cmd.Parameters.AddWithValue("@Investigation", payload.Investigation);
                    cmd.Parameters.AddWithValue("@InvestigationPro", payload.InvestigationPro);
                    cmd.Parameters.AddWithValue("@Medicine", payload.Medicine);
                    cmd.Parameters.AddWithValue("@MedicinePro", payload.MedicinePro);
                    cmd.Parameters.AddWithValue("@Nature", payload.Nature);
                    cmd.Parameters.AddWithValue("@NaturePro", payload.NaturePro);
                    cmd.Parameters.AddWithValue("@Perception", payload.Perception);
                    cmd.Parameters.AddWithValue("@PerceptionPro", payload.PerceptionPro);
                    cmd.Parameters.AddWithValue("@Performance", payload.Performance);
                    cmd.Parameters.AddWithValue("@PerformancePro", payload.PerformancePro);
                    cmd.Parameters.AddWithValue("@Persuasion", payload.Persuasion);
                    cmd.Parameters.AddWithValue("@PersuasionPro", payload.PersuasionPro);
                    cmd.Parameters.AddWithValue("@Religion", payload.Religion);
                    cmd.Parameters.AddWithValue("@ReligionPro", payload.ReligionPro);
                    cmd.Parameters.AddWithValue("@SleightofHand", payload.SleightofHand);
                    cmd.Parameters.AddWithValue("@SleightofHandPro", payload.SleightofHandPro);
                    cmd.Parameters.AddWithValue("@Stealth", payload.Stealth);
                    cmd.Parameters.AddWithValue("@StealthPro", payload.StealthPro);
                    cmd.Parameters.AddWithValue("@Survival", payload.Survival);
                    cmd.Parameters.AddWithValue("@SurvivalPro", payload.SurvivalPro);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }
            }
            return id;

        }

        //Skill Value Update
        public void PlayerSkillUpdate(PlayerSkillUpdateReq payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@CharacterId", payload.CharacterId);
                    cmd.Parameters.AddWithValue("@Acrobatics", payload.Acrobatics);
                    cmd.Parameters.AddWithValue("@AcrobaticsPro", payload.AcrobaticsPro);
                    cmd.Parameters.AddWithValue("@AnimalHandling", payload.AnimalHandling);
                    cmd.Parameters.AddWithValue("@AnimalHandlingPro", payload.AnimalHandlingPro);
                    cmd.Parameters.AddWithValue("@Arcana", payload.Arcana);
                    cmd.Parameters.AddWithValue("@ArcanaPro", payload.ArcanaPro);
                    cmd.Parameters.AddWithValue("@Athletics", payload.Athletics);
                    cmd.Parameters.AddWithValue("@AthleticsPro", payload.AthleticsPro);
                    cmd.Parameters.AddWithValue("@Deception", payload.Deception);
                    cmd.Parameters.AddWithValue("@DeceptionPro", payload.DeceptionPro);
                    cmd.Parameters.AddWithValue("@History", payload.History);
                    cmd.Parameters.AddWithValue("@HistoryPro", payload.HistoryPro);
                    cmd.Parameters.AddWithValue("@Insight", payload.Insight);
                    cmd.Parameters.AddWithValue("@InsightPro", payload.InsightPro);
                    cmd.Parameters.AddWithValue("@Intimidation", payload.Intimidation);
                    cmd.Parameters.AddWithValue("@IntimidationPro", payload.IntimidationPro);
                    cmd.Parameters.AddWithValue("@Investigation", payload.Investigation);
                    cmd.Parameters.AddWithValue("@InvestigationPro", payload.InvestigationPro);
                    cmd.Parameters.AddWithValue("@Medicine", payload.Medicine);
                    cmd.Parameters.AddWithValue("@MedicinePro", payload.MedicinePro);
                    cmd.Parameters.AddWithValue("@Nature", payload.Nature);
                    cmd.Parameters.AddWithValue("@NaturePro", payload.NaturePro);
                    cmd.Parameters.AddWithValue("@Perception", payload.Perception);
                    cmd.Parameters.AddWithValue("@PerceptionPro", payload.PerceptionPro);
                    cmd.Parameters.AddWithValue("@Performance", payload.Performance);
                    cmd.Parameters.AddWithValue("@PerformancePro", payload.PerformancePro);
                    cmd.Parameters.AddWithValue("@Persuasion", payload.Persuasion);
                    cmd.Parameters.AddWithValue("@PersuasionPro", payload.PersuasionPro);
                    cmd.Parameters.AddWithValue("@Religion", payload.Religion);
                    cmd.Parameters.AddWithValue("@ReligionPro", payload.ReligionPro);
                    cmd.Parameters.AddWithValue("@SleightofHand", payload.SleightofHand);
                    cmd.Parameters.AddWithValue("@SleightofHandPro", payload.SleightofHandPro);
                    cmd.Parameters.AddWithValue("@Stealth", payload.Stealth);
                    cmd.Parameters.AddWithValue("@StealthPro", payload.StealthPro);
                    cmd.Parameters.AddWithValue("@Survival", payload.Survival);
                    cmd.Parameters.AddWithValue("@SurvivalPro", payload.SurvivalPro);
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Skill Value GetByCharacterId
        public PlayerSkill PlayerSkillByCharId(int id)
        {
            PlayerSkill p = new PlayerSkill();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CharacterId", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int startingIndex = 0;
                        p.Id = reader.GetInt32(startingIndex++);
                        p.CharacterId = reader.GetInt32(startingIndex++);
                        p.Acrobatics = reader.GetInt32(startingIndex++);
                        p.AcrobaticsPro = reader.GetBoolean(startingIndex++);
                        p.AnimalHandling = reader.GetInt32(startingIndex++);
                        p.AnimalHandlingPro = reader.GetBoolean(startingIndex++);
                        p.Arcana = reader.GetInt32(startingIndex++);
                        p.ArcanaPro = reader.GetBoolean(startingIndex++);
                        p.Athletics = reader.GetInt32(startingIndex++);
                        p.AthleticsPro = reader.GetBoolean(startingIndex++);
                        p.Deception = reader.GetInt32(startingIndex++);
                        p.DeceptionPro = reader.GetBoolean(startingIndex++);
                        p.History = reader.GetInt32(startingIndex++);
                        p.HistoryPro = reader.GetBoolean(startingIndex++);
                        p.Insight = reader.GetInt32(startingIndex++);
                        p.InsightPro = reader.GetBoolean(startingIndex++);
                        p.Intimidation = reader.GetInt32(startingIndex++);
                        p.IntimidationPro = reader.GetBoolean(startingIndex++);
                        p.Investigation = reader.GetInt32(startingIndex++);
                        p.InvestigationPro = reader.GetBoolean(startingIndex++);
                        p.Medicine = reader.GetInt32(startingIndex++);
                        p.MedicinePro = reader.GetBoolean(startingIndex++);
                        p.Nature = reader.GetInt32(startingIndex++);
                        p.NaturePro = reader.GetBoolean(startingIndex++);
                        p.Perception = reader.GetInt32(startingIndex++);
                        p.PerceptionPro = reader.GetBoolean(startingIndex++);
                        p.Performance = reader.GetInt32(startingIndex++);
                        p.PerformancePro = reader.GetBoolean(startingIndex++);
                        p.Persuasion = reader.GetInt32(startingIndex++);
                        p.PersuasionPro = reader.GetBoolean(startingIndex++);
                        p.Religion = reader.GetInt32(startingIndex++);
                        p.ReligionPro = reader.GetBoolean(startingIndex++);
                        p.SleightofHand = reader.GetInt32(startingIndex++);
                        p.SleightofHandPro = reader.GetBoolean(startingIndex++);
                        p.Stealth = reader.GetInt32(startingIndex++);
                        p.StealthPro = reader.GetBoolean(startingIndex++);
                        p.Survival = reader.GetInt32(startingIndex++);
                        p.SurvivalPro = reader.GetBoolean(startingIndex++);
                    }
                }

            }
            return p;
        }


        //Processing Modifiers (private method)





        //Creation of Character Full Db Calls, details,stats,health,hitdice,deathsaves,skillvalues,skillspecialty
        public bool FullCharacterInsert (FullCharacterAddReq payload)
        {
            bool successCheck = true;
            List<int> checkArray = null;
            int a = CharacterDetailsInsert(payload.CharacterDetails);
            checkArray.Add(a);
            int b = MainStatsInsert(payload.MainStats);
            checkArray.Add(b);
            int c = HealthInsert(payload.Health);
            checkArray.Add(c);
            int d = HitDiceInsert(payload.HitDice);
            checkArray.Add(d);
            int e = DeathSavesInsert(payload.DeathSaves);
            checkArray.Add(e);
            int f = PlayerSkillInsert(payload.PlayerSkill);
            checkArray.Add(f);

            for (int i = 0; i < checkArray.Count; i++)
            {
                if (checkArray[i] == 0)
                {
                    successCheck = false;
                    throw new System.Exception("There was a problem with the insert at " + checkArray[i] + " index."); 
                }
            }

            return successCheck;

        }



        //Get Full Character Information with Modifiers, details,statvalues,modifiers,health,hitdice,deathsaves,skillvalues
        public FullCharacterInfo GetFullCharInfoByCharId(int id)
        {
            FullCharacterInfo FullCharInfo = new FullCharacterInfo();
            FullCharInfo.CharacterDetails = GetCharacterDetails(id);
            FullCharInfo.MainStats = MainStatsByCharId(id);
            FullCharInfo.MainStatModifiers = MainStatCalculate(FullCharInfo.MainStats);
            FullCharInfo.Health = HealthByCharId(id);
            FullCharInfo.HitDice = HitDiceByCharId(id);
            FullCharInfo.DeathSaves = DeathSavesByCharId(id);
            FullCharInfo.PlayerSkill = PlayerSkillByCharId(id); 
            return FullCharInfo;
        }


        private MainStatModifiers MainStatCalculate (MainStats stats)
        {
            MainStatModifiers modifiers = new MainStatModifiers();
            modifiers.StrengthPlus = ModifierCalculate(stats.Strength);
            modifiers.DexterityPlus = ModifierCalculate(stats.Dexterity);
            modifiers.ConstitutionPlus = ModifierCalculate(stats.Constitution);
            modifiers.IntelligencePlus = ModifierCalculate(stats.Intelligence);
            modifiers.WisdomPlus = ModifierCalculate(stats.Wisdom);
            modifiers.CharismaPlus = ModifierCalculate(stats.Charisma);
            return modifiers;
        }
        private static int GetSafeInt32(IDataReader reader, Int32 ordinal)
        {
            if (reader[ordinal] != null && Convert.IsDBNull(reader[ordinal]) == false)
            {
                return reader.GetInt32(ordinal);
            }
            else
            {
                return 0;
            }
        }
        private static string GetSafeString(IDataReader reader, Int32 ordinal, bool trim = true)
        {
            if (reader[ordinal] != null && reader[ordinal] != DBNull.Value)
            {
                if (trim)
                    return reader.GetString(ordinal).Trim();
                else
                    return reader.GetString(ordinal);
            }
            else
            {
                return null;
            }
        }
        private int ModifierCalculate(int num)
        {
            double ret = num-10;
            int mod = Convert.ToInt32(Math.Floor(ret/2));
            return mod;
        }
    }
}