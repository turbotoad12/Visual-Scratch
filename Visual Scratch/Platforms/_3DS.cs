using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Scratch.Platforms
{
    /// <summary>
    /// Represents the Nintendo 3DS platform for building projects.
    /// </summary>
    internal class _3DS : IPlatform
    {
        /// <summary>
        /// Gets or sets the name of the platform.
        /// </summary>
        public string Name { get; set; } = "Visual Scratch App";
        /// <summary>
        /// Gets or sets the description of the platform.
        /// </summary>
        public string Description { get; set; } = "A cool game.";
        /// <summary>
        /// Gets or sets the name of the author associated with the item.
        /// </summary>
        public string Author { get; set; } = "No one";

        /// <summary>
        /// Builds the project for the Nintendo 3DS platform.
        /// </summary>
        /// <exception cref="NotImplementedException">TBH I HAVENT DONE ANYTHING YET WITH TS</exception>
        public void Build()
        {
            throw new NotImplementedException("Nothing here rn. check back later.");
        }
        

    }
}
