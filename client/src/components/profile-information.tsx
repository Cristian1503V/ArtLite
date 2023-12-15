import Image from "next/image"
import { Creator } from "@/api/types"
import { cn } from "@/libs/utils"

import { ButtonLink } from "./button-link"
import CardWrapper from "./card-wrapper"
import CreatorSocials from "./creator-socials"
import ToggleText from "./toggle-text"

interface ProfileInformationProps {
  creator: Creator
}

export default function ProfileInformation({
  creator,
}: ProfileInformationProps) {
  const {
    profileImage,
    username,
    highlightedPhrase,
    email,
    biography,
    socials,
  } = creator

  const { facebook, instagram, linkedin, figma, youtube } = socials

  return (
    <CardWrapper>
      <div className="flex flex-col items-center justify-center gap-1">
        <div className="mb-2 h-36 w-36">
          <Image
            src={profileImage ?? "default_avatar.webp"}
            alt={`profile Image for ${username}`}
            width={160}
            height={160}
            className="rounded-full object-cover"
          />
        </div>

        <div className="flex w-full flex-col items-center justify-center gap-1">
          <span className="text-[21px] font-extrabold">{username}</span>
          <span className="text-secondary-foreground text-[13px]">
            {highlightedPhrase}
          </span>
        </div>
      </div>

      <div className="flex w-full items-center justify-center gap-4">
        <ButtonLink
          variant="primary"
          icon="userPlus"
          href=""
          className="cursor-not-allowed px-6 "
        >
          Follow
        </ButtonLink>

        <ButtonLink
          variant="secondary"
          icon="mailPlus"
          href={`mailto:${email}`}
          className="px-6"
        >
          Message
        </ButtonLink>
      </div>

      <ToggleText text={biography} />

      <div className="h-[2px] w-full bg-[#404044]"></div>

      <div className="flex flex-col gap-6">
        <span className="text-[13px]">Follow in social</span>
        <div className="flex gap-2">
          {facebook && <CreatorSocials icon="facebook" href={facebook} />}
          {instagram && <CreatorSocials icon="instagram" href={instagram} />}
          {linkedin && <CreatorSocials icon="linkedin" href={linkedin} />}
          {figma && <CreatorSocials icon="figma" href={figma} />}
          {youtube && <CreatorSocials icon="youtube" href={youtube} />}
        </div>
      </div>

      <div className="h-[2px] w-full bg-[#404044]"></div>
    </CardWrapper>
  )
}
