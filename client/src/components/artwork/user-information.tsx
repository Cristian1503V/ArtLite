import React from "react"
import Image from "next/image"
import Link from "next/link"
import { ArtWork } from "@/api/types"

import { urls } from "@/config/urls"
import { ButtonLink } from "@/components/button-link"
import { CardWrapper } from "@/components/card-wrapper"
import { ToggleText } from "@/components/toggle-text"

interface UserInfomationProps {
  artWork: Pick<ArtWork, "description" | "title" | "idArtwork" | "creator">
}

export function UserInfomation({ artWork }: UserInfomationProps) {
  const { title, description, creator } = artWork
  const { profileImage, username } = creator

  return (
    <CardWrapper>
      <div className="flex items-center justify-center gap-2">
        <Link href={urls.creator(creator.slug)}>
          <Image
            src={profileImage ?? "default_avatar.webp"}
            alt={`profile Image for ${username}`}
            width={90}
            height={90}
            className="rounded-full"
          />
        </Link>
        <div className="flex w-full flex-col items-start gap-2">
          <Link
            className="hover:text-accent w-full font-extrabold tracking-tighter transition-all xl:text-[19px] 2xl:text-[22px]"
            href={urls.creator(creator.slug)}
          >
            {username}
          </Link>
          <button className="rounded-md border-[0.01px] border-[#96969a] px-3 py-[2px] text-xs">
            Follow
          </button>
        </div>
      </div>

      <div className="flex w-full items-center justify-center gap-4">
        <ButtonLink
          variant="primary"
          icon="heart"
          href=""
          className="px-10"
          classIcon="fill-current"
        >
          Like
        </ButtonLink>

        <ButtonLink
          variant="secondary"
          icon="bookmark"
          href=""
          className="cursor-not-allowed px-10"
          classIcon="fill-current"
        >
          save
        </ButtonLink>
      </div>

      <div className="bg-muted mt-2 h-[2px] w-full"></div>

      <div className="mt-3 flex flex-col gap-1">
        <span className="text-lg font-bold tracking-tighter">{title}</span>
        <ToggleText text={description} />
      </div>
    </CardWrapper>
  )
}
