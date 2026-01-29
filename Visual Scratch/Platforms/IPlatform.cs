using System;
using System.Threading;
using System.Threading.Tasks;

namespace Visual_Scratch.Platforms
{
    public interface IPlatform 
    {
        Core.Project Project { get; set; }

        // Make sure DockerBuildOptions is public to match the interface's accessibility
        Core.Docker.DockerBuildOptions BuildOptions { get; set; }

        Task BuildAsync(IProgress<int> progress, CancellationToken cancellationToken);

    }
}
