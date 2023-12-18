import React from "react"
import { notFound, redirect } from "next/navigation"
import { getArwork } from "@/api/actions"
import toast from "react-hot-toast"

import { urls } from "@/config/urls"
import { Artwork } from "@/components/artwork/artwork"
import { DeleteButton } from "@/components/artwork/delete-button"
import { TagItem } from "@/components/artwork/tag-item"
import { UserInfomation } from "@/components/artwork/user-information"
import { Aside } from "@/components/aside"
import { CardWrapper } from "@/components/card-wrapper"

interface ArtworkPageProps {
  params: {
    id: string
  }
}

async function getData(idArtWork: string) {
  try {
    return await getArwork(idArtWork)
  } catch (error) {
    return undefined
  }
}

export default async function ArtworkPage({ params }: ArtworkPageProps) {
  const { id } = params
  const artwork = await getData(id)

  // si la pagina no se encuentra
  if (!artwork) notFound()

  const { title, tags, creator, idArtwork, description } = artwork

  const onDelete = async () => {
    "use server"
    // deleteArwork(idArtwork)
    return redirect(urls.creator(creator.slug))
  }

  return (
    <div className="relative flex h-full w-full flex-1 gap-6 px-6">
      <div className="relative flex h-full w-full gap-6">
        <Artwork artwork={artwork} />

        <Aside>
          <UserInfomation
            artWork={{ description, title, idArtwork, creator }}
          />

          <div className="flex flex-col gap-2">
            {tags.length > 0 && (
              <>
                <span className="text-xs font-bold text-[#96969a]">{`${tags.length} TAGS`}</span>
                <CardWrapper>
                  <div className="flex flex-wrap gap-2">
                    {tags?.map((tag) => {
                      return <TagItem key={tag} tag={tag} />
                    })}
                  </div>
                </CardWrapper>
              </>
            )}
          </div>

          <div>
            <CardWrapper>
              <span className="text-foreground text-sm font-bold">Options</span>
              <DeleteButton handler={onDelete}>Delete</DeleteButton>
            </CardWrapper>
          </div>
        </Aside>
      </div>
    </div>
  )
}
