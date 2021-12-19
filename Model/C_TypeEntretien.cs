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
 public class C_TypeEntretien
 {
  #region Données membres
  private int _id;
  private string _nom;
  private Int64 _kilometrage;
  #endregion
  #region Constructeurs
  public C_TypeEntretien()
  { }
  public C_TypeEntretien(string nom_, Int64 kilometrage_)
  {
   nom = nom_;
   kilometrage = kilometrage_;
  }
  public C_TypeEntretien(int id_, string nom_, Int64 kilometrage_)
   : this(nom_, kilometrage_)
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
  public string nom
  {
   get { return _nom; }
   set { _nom = value; }
  }
  public Int64 kilometrage
  {
   get { return _kilometrage; }
   set { _kilometrage = value; }
  }
  #endregion
 }
}
