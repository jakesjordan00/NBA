﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nbaJSON
{
    public partial class Bus_Driver : System.Web.UI.Page
    {
        static int game = 0;
        public global::System.Web.UI.WebControls.Label statusL;
        public global::System.Web.UI.HtmlControls.HtmlGenericControl gameColumnC;
        public global::System.Web.UI.WebControls.Label gamesCreatedLbl;
        public global::System.Web.UI.HtmlControls.HtmlGenericControl gameColumnU;
        public global::System.Web.UI.WebControls.Label gamesUpdatedLbl;

        public global::System.Web.UI.HtmlControls.HtmlGenericControl teamColumnC;
        public global::System.Web.UI.WebControls.Label boxTeamsCreatedLbl;
        public global::System.Web.UI.HtmlControls.HtmlGenericControl teamColumnU;
        public global::System.Web.UI.WebControls.Label boxTeamsUpdatedLbl;

        public global::System.Web.UI.HtmlControls.HtmlGenericControl homePlayerColumnC;
        public global::System.Web.UI.WebControls.Label boxHomePlayersCreatedLbl;
        public global::System.Web.UI.HtmlControls.HtmlGenericControl homePlayerColumnU;
        public global::System.Web.UI.WebControls.Label boxHomePlayersUpdatedLbl;

        public global::System.Web.UI.HtmlControls.HtmlGenericControl AwayPlayerColumnC;
        public global::System.Web.UI.WebControls.Label boxAwayPlayersCreatedLbl;
        public global::System.Web.UI.HtmlControls.HtmlGenericControl AwayPlayerColumnU;
        public global::System.Web.UI.WebControls.Label boxAwayPlayersUpdatedLbl;




        public static string ConnectionString = "Server=localhost;Database=myNBA;User Id=test;Password=test123;";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void loadB_Click(object sender, EventArgs e)
        {
            earlyBird.earlyBird.LoadCheck(statusL);
        }




        protected void gameB_Click(object sender, EventArgs e)
        {
            gameRider.gameRider.CheckGames(gamesCreatedLbl, gamesUpdatedLbl);
            gameColumnC.Visible = true;
            gamesCreatedLbl.Visible = true;
            gameColumnU.Visible = true;
            gamesUpdatedLbl.Visible = true;

        }

        protected void boxB_Click(object sender, EventArgs e)
        {
            boxRider.boxRider.CheckGames(gamesCreatedLbl, gamesUpdatedLbl, boxTeamsCreatedLbl, boxTeamsUpdatedLbl, boxHomePlayersCreatedLbl, boxHomePlayersUpdatedLbl, boxAwayPlayersCreatedLbl, boxAwayPlayersUpdatedLbl);
            gameColumnC.Visible = true;
            gamesCreatedLbl.Visible = true;
            gameColumnU.Visible = true;
            gamesUpdatedLbl.Visible = true;
            teamColumnC.Visible = true;
            boxTeamsCreatedLbl.Visible = true;
            teamColumnU.Visible = true;
            boxTeamsUpdatedLbl.Visible = true;
            homePlayerColumnC.Visible = true;
            boxHomePlayersCreatedLbl.Visible = true;
            homePlayerColumnU.Visible = true;
            boxHomePlayersUpdatedLbl.Visible = true;
            AwayPlayerColumnC.Visible = true;
            boxAwayPlayersCreatedLbl.Visible = true;
            AwayPlayerColumnU.Visible = true;
            boxAwayPlayersUpdatedLbl.Visible = true;
        }


        protected void pbpB_Click(object sender, EventArgs e)
        {
            //Get count of games
            SqlConnection sqlConnect = new SqlConnection(Bus_Driver.ConnectionString);
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("jsonGames"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GamesGrid.DataSource = dataT;
                            GamesGrid.DataBind();
                        }
                    }
                }
            }
            //For each game_id, get the JSON file for the game
            foreach (GridViewRow row in GamesGrid.Rows)
            {
                game = Int32.Parse(row.Cells[0].Text);
                pbpRider.pbpRider.GetGameJson(game);
            }
        }

        protected void playoffB_Click(object sender, EventArgs e)
        {
            playoffRider.playoffRider.init();
        }
    }
}