using System.Collections.Generic;
using System.Linq;

#pragma warning disable CA1819 // Properties should not return arrays

namespace ExtenFlow.Security.Users.Handlers
{
    /// <summary>
    /// Represents a <see cref="UserContextBase"/> for updated user roles.
    /// </summary>
    public class UpdateRolesContext : UserContextBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="UpdateRolesContext"/>.
        /// </summary>
        /// <param name="user">The <see cref="IUser"/>.</param>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="externalClaims">The user claims.</param>
        /// <param name="userRoles">The user roles</param>
        public UpdateRolesContext(IUser user, string loginProvider, IEnumerable<SerializableClaim> externalClaims, IEnumerable<string> userRoles) : base(user)
        {
            ExternalClaims = externalClaims.AsEnumerable();
            UserRoles = userRoles;
            LoginProvider = loginProvider;
        }

        /// <summary>
        /// Gets the login provider.
        /// </summary>
        public string LoginProvider { get; }

        /// <summary>
        /// Gets a list of external claims.
        /// </summary>
        public IEnumerable<SerializableClaim> ExternalClaims { get; }

        /// <summary>
        /// Gets the user's roles.
        /// </summary>
        public IEnumerable<string> UserRoles { get; }

        /// <summary>
        /// Gets the roles to be added to the user roles.
        /// </summary>
        public string[] RolesToAdd { get; set; } = System.Array.Empty<string>();

        /// <summary>
        /// Gets the roles to be removed from the user roles.
        /// </summary>
        public string[] RolesToRemove { get; set; } = System.Array.Empty<string>();
    }
}