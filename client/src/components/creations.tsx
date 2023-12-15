"use client"

import Image from "next/image"
import { notFound } from "next/navigation"
import { getCreator } from "@/api/actions"
import { ArtWorkThumbnail, Creator } from "@/api/types"
import { useQuery } from "react-query"

import { Thumbnail } from "./thumbnail"

interface CreatorProps {
  creator: Creator
}

export default function Creations({ creator }: CreatorProps) {
  const { slug } = creator

  const { data, isLoading, error } = useQuery({
    queryKey: "creatorRequest",
    queryFn: () => getCreator(slug),
    initialData: creator,
  })

  if (!data) notFound()

  const { artworks, profileBanner } = data

  return (
    <div className="flex h-full w-full basis-[100%] flex-col gap-6 pb-6">
      <div className="flex h-[307px] w-full items-center justify-center overflow-hidden rounded-2xl">
        <Image
          src={profileBanner ?? ""}
          alt=""
          width={1980}
          height={640}
          className="object-cover"
        />
      </div>

      <div className="flex items-center gap-3">
        <span className="text-[21px] font-extrabold">Portafolio</span>
        <span className="text-secondary-foreground text-[15px]">
          {artworks.length} artworks
        </span>
      </div>

      <div className="grid h-full w-full gap-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-6">
        {artworks?.map((artwork) => {
          const artWorkThumbnail = { ...artwork, creator }
          return (
            <Thumbnail key={artwork.idArtwork} artwork={artWorkThumbnail} />
          )
        })}
      </div>
    </div>
  )
}
