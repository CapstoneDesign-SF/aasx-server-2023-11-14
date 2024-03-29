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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AccessControl : IEquatable<AccessControl>
    {
        /// <summary>
        /// Gets or Sets AccessPermissionRule
        /// </summary>

        [DataMember(Name = "accessPermissionRule")]
        public List<AccessPermissionRule> AccessPermissionRule { get; set; }

        /// <summary>
        /// Gets or Sets DefaultEnvironmentAttributes
        /// </summary>

        [DataMember(Name = "defaultEnvironmentAttributes")]
        //TODO:Uncomment
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasReference DefaultEnvironmentAttributes { get; set; }
        public Reference DefaultEnvironmentAttributes { get; set; }

        /// <summary>
        /// Gets or Sets DefaultPermissions
        /// </summary>

        [DataMember(Name = "defaultPermissions")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasReference DefaultPermissions { get; set; }
        public Reference DefaultPermissions { get; set; }

        /// <summary>
        /// Gets or Sets DefaultSubjectAttributes
        /// </summary>

        [DataMember(Name = "defaultSubjectAttributes")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasReference DefaultSubjectAttributes { get; set; }
        public Reference DefaultSubjectAttributes { get; set; }

        /// <summary>
        /// Gets or Sets SelectableEnvironmentAttributes
        /// </summary>

        [DataMember(Name = "selectableEnvironmentAttributes")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasReference SelectableEnvironmentAttributes { get; set; }
        public Reference SelectableEnvironmentAttributes { get; set; }

        /// <summary>
        /// Gets or Sets SelectablePermissions
        /// </summary>

        [DataMember(Name = "selectablePermissions")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasReference SelectablePermissions { get; set; }
        public Reference SelectablePermissions { get; set; }

        /// <summary>
        /// Gets or Sets SelectableSubjectAttributes
        /// </summary>

        [DataMember(Name = "selectableSubjectAttributes")]
        //TODO:
        //public HttpsapiSwaggerhubComdomainsPlattformI40SharedDomainModelsFinalDraftcomponentsschemasReference SelectableSubjectAttributes { get; set; }
        public Reference SelectableSubjectAttributes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccessControl {\n");
            sb.Append("  AccessPermissionRule: ").Append(AccessPermissionRule).Append("\n");
            sb.Append("  DefaultEnvironmentAttributes: ").Append(DefaultEnvironmentAttributes).Append("\n");
            sb.Append("  DefaultPermissions: ").Append(DefaultPermissions).Append("\n");
            sb.Append("  DefaultSubjectAttributes: ").Append(DefaultSubjectAttributes).Append("\n");
            sb.Append("  SelectableEnvironmentAttributes: ").Append(SelectableEnvironmentAttributes).Append("\n");
            sb.Append("  SelectablePermissions: ").Append(SelectablePermissions).Append("\n");
            sb.Append("  SelectableSubjectAttributes: ").Append(SelectableSubjectAttributes).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return obj.GetType() == GetType() && Equals((AccessControl)obj);
        }

        /// <summary>
        /// Returns true if AccessControl instances are equal
        /// </summary>
        /// <param name="other">Instance of AccessControl to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccessControl other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    AccessPermissionRule == other.AccessPermissionRule ||
                    AccessPermissionRule != null &&
                    AccessPermissionRule.SequenceEqual(other.AccessPermissionRule)
                ) &&
                (
                    DefaultEnvironmentAttributes == other.DefaultEnvironmentAttributes ||
                    DefaultEnvironmentAttributes != null &&
                    DefaultEnvironmentAttributes.Equals(other.DefaultEnvironmentAttributes)
                ) &&
                (
                    DefaultPermissions == other.DefaultPermissions ||
                    DefaultPermissions != null &&
                    DefaultPermissions.Equals(other.DefaultPermissions)
                ) &&
                (
                    DefaultSubjectAttributes == other.DefaultSubjectAttributes ||
                    DefaultSubjectAttributes != null &&
                    DefaultSubjectAttributes.Equals(other.DefaultSubjectAttributes)
                ) &&
                (
                    SelectableEnvironmentAttributes == other.SelectableEnvironmentAttributes ||
                    SelectableEnvironmentAttributes != null &&
                    SelectableEnvironmentAttributes.Equals(other.SelectableEnvironmentAttributes)
                ) &&
                (
                    SelectablePermissions == other.SelectablePermissions ||
                    SelectablePermissions != null &&
                    SelectablePermissions.Equals(other.SelectablePermissions)
                ) &&
                (
                    SelectableSubjectAttributes == other.SelectableSubjectAttributes ||
                    SelectableSubjectAttributes != null &&
                    SelectableSubjectAttributes.Equals(other.SelectableSubjectAttributes)
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
                if (AccessPermissionRule != null)
                    hashCode = hashCode * 59 + AccessPermissionRule.GetHashCode();
                if (DefaultEnvironmentAttributes != null)
                    hashCode = hashCode * 59 + DefaultEnvironmentAttributes.GetHashCode();
                if (DefaultPermissions != null)
                    hashCode = hashCode * 59 + DefaultPermissions.GetHashCode();
                if (DefaultSubjectAttributes != null)
                    hashCode = hashCode * 59 + DefaultSubjectAttributes.GetHashCode();
                if (SelectableEnvironmentAttributes != null)
                    hashCode = hashCode * 59 + SelectableEnvironmentAttributes.GetHashCode();
                if (SelectablePermissions != null)
                    hashCode = hashCode * 59 + SelectablePermissions.GetHashCode();
                if (SelectableSubjectAttributes != null)
                    hashCode = hashCode * 59 + SelectableSubjectAttributes.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(AccessControl left, AccessControl right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccessControl left, AccessControl right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
