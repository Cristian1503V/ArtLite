"use client"

import { notFound } from "next/navigation"
import { getArwork } from "@/api/actions"
import { ArtWork } from "@/api/types"
import { useQuery } from "react-query"

import { Portrait } from "@/components/artwork/portrait"

interface ArtWorksProps {
  artwork: ArtWork
}

export function Artwork({ artwork }: ArtWorksProps) {
  const { idArtwork } = artwork

  const { data, isLoading, error } = useQuery({
    queryKey: ["artwork", "artworkid", idArtwork],
    queryFn: () => getArwork(idArtwork),
    initialData: artwork,
  })

  if (!data) notFound()

  let gallery
  const { images, title } = data
  images.sort((a, b) => a.order - b.order)
  if (images.length > 1) {
    const [thumbnail, ...rest] = images
    gallery = rest
  } else {
    gallery = images
  }

  return (
    <div className="bg-thumbnailContainer mb-4 flex basis-[100%] flex-col gap-8 rounded-2xl py-5">
      {gallery?.map((image) => (
        <Portrait key={image.order} src={image.src} name={title} />
      ))}
    </div>
  )
}
