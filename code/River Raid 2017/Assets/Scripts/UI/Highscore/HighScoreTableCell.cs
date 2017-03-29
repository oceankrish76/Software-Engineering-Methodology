using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tacticsoft.Examples
{


    public class HighScoreTableCell : TableViewCell
    {

        //Inherit from TableViewCell instead of MonoBehavior to use the GameObject
        //containing this component as a cell in a TableView

        public Text _playername;
        public Text _playerscore;

        public void SetRowNumber(int rowNumber)
        {
            _playername.text = "Player " + rowNumber.ToString();
        }

        private int m_numTimesBecameVisible;
        public void NotifyBecameVisible()
        {
            m_numTimesBecameVisible++;
            _playerscore.text = "# rows this cell showed : " + m_numTimesBecameVisible.ToString();
        }

    }
}
