/*
 * DotAAS Part 2 | HTTP/REST | Asset Administration Shell Repository
 *
 * An exemplary interface combination for the use case of an Asset Administration Shell Repository
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class BasicEvent : ModelEvent, IEquatable<BasicEvent>
    {
        /// <summary>
        /// Gets or Sets Observed
        /// </summary>
        [Required]

        [DataMember(Name = "observed")]
        public Reference Observed { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BasicEvent {\n");
            sb.Append("  Observed: ").Append(Observed).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((BasicEvent)obj);
        }

        /// <summary>
        /// Returns true if BasicEvent instances are equal
        /// </summary>
        /// <param name="other">Instance of BasicEvent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BasicEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Observed == other.Observed ||
                    Observed != null &&
                    Observed.Equals(other.Observed)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Observed != null)
                    hashCode = hashCode * 59 + Observed.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(BasicEvent left, BasicEvent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BasicEvent left, BasicEvent right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
