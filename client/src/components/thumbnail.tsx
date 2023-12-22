import Image from "next/image"
import Link from "next/link"
import { ArtWorkThumbnail } from "@/api/types"

import { urls } from "@/config/urls"

interface ThumbnailProps {
  artwork: ArtWorkThumbnail
}

export function Thumbnail({ artwork }: ThumbnailProps) {
  const { thumbnail, title, creator, idArtwork } = artwork
  const { profileImage, username, idCreator } = creator

  return (
    <Link
      className="group relative h-full w-full overflow-hidden rounded-md"
      href={urls.artwork(idArtwork)}
    >
      <Image
        src={thumbnail}
        alt={title}
        width={400}
        height={400}
        quality={100}
      />

      <div className="group-hover:animate-fade animate-ease-in-out absolute bottom-0 z-10 hidden h-full w-full bg-gradient-to-t from-black via-transparent group-hover:block">
        <div className="group-hover:animate-fade-right animate-normal absolute bottom-0 flex items-center gap-2 px-2 py-4">
          <Image
            src={profileImage ?? ""}
            alt={username}
            className="rounded-full object-cover"
            width={35}
            height={35}
          />

          <div className="flex flex-col">
            <span className="line-clamp-1 text-sm font-bold text-white">
              {title}
            </span>
            <span className="font-base text-xs text-white">{username}</span>
          </div>
        </div>
      </div>
    </Link>
  )
}
