"use client"

import Image from "next/image"
import Link from "next/link"
import { notFound } from "next/navigation"
import { getCreator } from "@/api/actions"
import { Creator } from "@/api/types"
import { useQuery } from "react-query"

import { urls } from "@/config/urls"
import { Icons } from "@/components/icons"

import { Thumbnail } from "../thumbnail"

interface CreatorProps {
  creator: Creator
}

export function Creations({ creator }: CreatorProps) {
  const { slug, idCreator } = creator

  const { data, isLoading, error } = useQuery({
    queryKey: ["creator", "idCreator", idCreator],
    queryFn: () => getCreator(slug),
    initialData: creator,
  })

  if (!data) notFound()

  const { artworks, profileBanner } = data

  return (
    <div className="flex h-full w-full basis-[100%] flex-col gap-6 pb-4">
      <div className="flex h-60 w-full items-center justify-center overflow-hidden rounded-2xl xl:h-60 2xl:h-80">
        <img src={profileBanner ?? ""} alt="banner" className="object-cover" />
      </div>

      <div className="flex items-center gap-3">
        <span className="text-[21px] font-extrabold">Portafolio</span>
        <span className="text-secondary-foreground text-[15px]">
          {artworks.length} artworks
        </span>
      </div>

      {artworks.length > 0 ? (
        <div className="grid h-full w-full gap-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-6">
          {artworks?.map((artwork) => {
            const artWorkThumbnail = { ...artwork, creator }

            return (
              <Thumbnail key={artwork.idArtwork} artwork={artWorkThumbnail} />
            )
          })}
        </div>
      ) : (
        <div className="flex h-full w-full flex-col items-center">
          <Image
            src="https://cdn.artstation.com/assets/profile/projects.svg"
            alt="notArtwork"
            width={360}
            height={280}
            className="object-contain"
          />
          <span className="text-[30px] font-extralight ">
            Upload your artwork
          </span>

          <span className="text-secondary-foreground text-center text-[14px] ">
            Fill your portfolio with projects you are proud of.
            <br />
            Get feedback on your work and build your industry network.
          </span>

          <Link
            href={urls.create}
            className="hover:bg-muted mt-6 flex cursor-pointer gap-2 rounded-md border border-[#525257] px-4  py-3 text-[14px] transition-all"
          >
            <Icons.image className="text-accent h-5 w-5" />
            Upload a project
          </Link>
        </div>
      )}
    </div>
  )
}
