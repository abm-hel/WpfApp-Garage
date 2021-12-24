#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_Garage.Model;
using Projet_Garage.Acces;
#endregion

namespace Projet_Garage.Model
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_TypeEntretien : G_Base
 {
  #region Constructeurs
  public G_TypeEntretien()
   : base()
  { }
  public G_TypeEntretien(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string nom, Int64 kilometrage)
  { return new A_TypeEntretien(ChaineConnexion).Ajouter(nom, kilometrage); }
  public int Modifier(int id, string nom, Int64 kilometrage)
  { return new A_TypeEntretien(ChaineConnexion).Modifier(id, nom, kilometrage); }
  public List<C_TypeEntretien> Lire(string Index)
  { return new A_TypeEntretien(ChaineConnexion).Lire(Index); }
  public C_TypeEntretien Lire_ID(int id)
  { return new A_TypeEntretien(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_TypeEntretien(ChaineConnexion).Supprimer(id); }
 }
}
