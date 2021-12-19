#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Projet_Garage.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_Entretien
 {
  #region Données membres
  private int _id;
  private int? _vehiculeId;
  private DateTime? _datePassage;
  #endregion
  #region Constructeurs
  public C_Entretien()
  { }
  public C_Entretien(int? vehiculeId_, DateTime? datePassage_)
  {
   vehiculeId = vehiculeId_;
   datePassage = datePassage_;
  }
  public C_Entretien(int id_, int? vehiculeId_, DateTime? datePassage_)
   : this(vehiculeId_, datePassage_)
  {
   id = id_;
  }
  #endregion
  #region Accesseurs
  public int id
  {
   get { return _id; }
   set { _id = value; }
  }
  public int? vehiculeId
  {
   get { return _vehiculeId; }
   set { _vehiculeId = value; }
  }
  public DateTime? datePassage
  {
   get { return _datePassage; }
   set { _datePassage = value; }
  }
  #endregion
 }
}
