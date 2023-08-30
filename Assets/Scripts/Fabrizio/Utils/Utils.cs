using UnityEngine;

namespace Fabrizio.Utils
{
    public static class Utils
    {
        public static float Collision2DImpulse(Collision2D col)
        {
            ContactPoint2D[] contacts = new ContactPoint2D[col.contactCount];
            col.GetContacts(contacts);
            float impulse = 0f;
            foreach (ContactPoint2D contact in contacts)
            {
                impulse += contact.normalImpulse;
            }
            return impulse;
        }
    }
}