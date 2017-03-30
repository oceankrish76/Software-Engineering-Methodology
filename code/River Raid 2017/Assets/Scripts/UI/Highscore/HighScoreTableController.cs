using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tacticsoft;

namespace Tacticsoft.Examples
{
    public class HighScoreTableController : MonoBehaviour, ITableViewDataSource
    {
        public HighScoreTableCell m_cellPrefab;
        public TableView m_tableView;



        public int m_numRows;
        private int m_numInstancesCreated = 0;
        private List<Highscore> highscores;

        //Register as the TableView's delegate (required) and data source (optional)
        //to receive the calls
        void Start()
        {
            m_tableView.dataSource = this;
            highscores = FindObjectOfType<SaveAndLoadHighscores>().Load();
            m_numRows = highscores.Count;
        }

        #region ITableViewDataSource

        //Will be called by the TableView to know how many rows are in this table
        public int GetNumberOfRowsForTableView(TableView tableView)
        {
            return m_numRows;
        }

        //Will be called by the TableView to know what is the height of each row
        public float GetHeightForRowInTableView(TableView tableView, int row)
        {
            return (m_cellPrefab.transform as RectTransform).rect.height;
        }

        //Will be called by the TableView when a cell needs to be created for display
        public TableViewCell GetCellForRowInTableView(TableView tableView, int row)
        {
            HighScoreTableCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as HighScoreTableCell;
            if (cell == null)
            {
                cell = (HighScoreTableCell)GameObject.Instantiate(m_cellPrefab);
                cell.name = "highscore1" + (++m_numInstancesCreated).ToString();
            }
    
            if(m_numInstancesCreated < m_numRows)
            {
                cell.SetPlayerName(highscores[m_numInstancesCreated].name);
                cell.SetPlayerScore(highscores[m_numInstancesCreated].score);
            }

            return cell;
        }

        #endregion

        #region Table View event handlers

        //Will be called by the TableView when a cell's visibility changed
        public void TableViewCellVisibilityChanged(int row, bool isVisible)
        {
            //Debug.Log(string.Format("Row {0} visibility changed to {1}", row, isVisible));
            if (isVisible)
            {
                HighScoreTableCell cell = (HighScoreTableCell)m_tableView.GetCellAtRow(row);
                cell.NotifyBecameVisible();
            }
        }

        #endregion

    }
}
