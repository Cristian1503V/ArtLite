import Image from "next/image"
import { formatBytes } from "@/libs/utils"

import { PreviewableFile } from "@/config/types"
import { Icons } from "@/components/icons"

interface PreviewImageProps {
  file: PreviewableFile
  closeHandler: React.MouseEventHandler<HTMLButtonElement>
}

export function PreviewImage({ file, closeHandler }: PreviewImageProps) {
  return (
    <div className="relative flex flex-col gap-6 rounded-md border-[1px] border-[#303034]">
      <div className="flex h-full w-full items-center justify-center gap-5 overflow-hidden rounded-t-md bg-black py-10">
        <Image
          src={file.preview}
          alt="ImagePreview"
          width={450}
          height={137}
          onLoad={() => {
            URL.revokeObjectURL(file.preview)
          }}
          className="max-h-full max-w-full object-cover"
        />
      </div>

      <div className="absolute top-0 flex w-full justify-between p-2 ">
        <div className="flex items-center justify-center gap-2 ">
          <Icons.image className="h-5 w-5" />
          <span className="line-clamp-1 text-[11px]">
            {formatBytes(file.size)}
          </span>
        </div>

        <button type="button" className="" onClick={closeHandler}>
          <Icons.close className="hover:text-accent-hover h-5 w-5" />
        </button>
      </div>
    </div>
  )
}
