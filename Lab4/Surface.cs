﻿using Psim.Particles;
using Psim.Geometry2D;

namespace Psim.ModelComponents
{
	public interface ISurface
	{
		Cell HandlePhonon(Phonon p);
	}

	public class BoundarySurface : ISurface
	{
		public SurfaceLocation Location { get; }
		protected Cell cell;


		// To location and cell
		public BoundarySurface(SurfaceLocation location, Cell cell)
		{
			Location = location;
			this.cell = cell;
		}

		// To handle phonon base on condition
		public virtual Cell HandlePhonon(Phonon p)
		{
			Vector direction = p.Direction;
			if(Location == SurfaceLocation.left || Location == SurfaceLocation.right)
            {
				p.SetDirection(-direction.DX, direction.DY);
            }
            else
            {
				p.SetDirection(direction.DX, -direction.DY);
			}
			// Only need to account for perfectly specular reflection
			// TODO: Alter the phonon direction vector as though it just collided with a mirror
			return cell;
		}
	}
}
