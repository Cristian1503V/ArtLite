import { useCallback, useEffect, useState } from "react"
import { cn } from "@/libs/utils"
import { DropEvent, FileRejection, useDropzone } from "react-dropzone"
import { ControllerRenderProps } from "react-hook-form"
import { v4 as uuidv4 } from "uuid"

import { PreviewableFile } from "@/config/types"
import { FormSchema } from "@/components/forms/artwork-create-form"
import { Icons } from "@/components/icons"

import { PreviewImage } from "./preview-image"

type DropType = <T extends File>(
  acceptedFiles: T[],
  fileRejections: FileRejection[],
  event: DropEvent
) => void

export function DropArea({
  name,
  onBlur,
  onChange,
  value: images,
}: Omit<ControllerRenderProps<FormSchema, "images">, "ref">) {
  const [files, setFiles] = useState<PreviewableFile[]>([])

  const onDrop: DropType = useCallback(
    (droppedFiles) => {
      setFiles((currentFiles) => [
        ...currentFiles,
        ...droppedFiles.map((file) =>
          Object.assign(file, {
            preview: URL.createObjectURL(file),
            id: uuidv4(),
          })
        ),
      ])
    },
    [setFiles]
  )

  const closeImageHandler = (fileId: string) => {
    setFiles((currentFiles) =>
      currentFiles.filter((file) => file.id !== fileId)
    )
  }

  const { getInputProps, getRootProps, isDragAccept, isDragReject, isFocused } =
    useDropzone({
      onDrop,
      accept: { "image/*": [] },
    })

  useEffect(() => {
    onChange(files)
    return () => files.forEach((file) => URL.revokeObjectURL(file.preview))
  }, [files, onChange])

  return (
    <div className="flex w-full flex-col  gap-8 px-4 py-6">
      <section
        className={cn(
          "flex w-full cursor-pointer flex-col gap-6 rounded-md border-[2px] border-dashed border-[#303034] px-2 pb-20 transition-all",
          (isDragAccept || isFocused) &&
            "border-accent-hover bg-[#303034] opacity-50",
          isDragReject && "border-red-400 bg-[#303034] opacity-50"
        )}
        {...getRootProps({})}
      >
        <div className="border-b border-[#303034] py-2">
          <div className="flex w-28 flex-col border-r border-[#303034] pr-2 ">
            <div className="hover:bg-muted flex cursor-pointer flex-col items-center justify-center rounded-md py-4 transition-all">
              <input className="hidden" {...getInputProps()} />
              <Icons.image className="text-accent" />
              <span className="text-[14px] font-bold">HQ Images</span>
              <span className="text-secondary-foreground text-[12px]">
                JPG,JPEG,PNG
              </span>
            </div>
          </div>
        </div>

        <div className="z-30 py-11">
          <input className="hidden" {...getInputProps()} />
          <div className="flex w-full items-center justify-center">
            <span className="hover:bg-muted flex cursor-pointer gap-2 rounded-md border border-[#303034] px-3 py-2 text-[14px] transition-all">
              <Icons.image className="text-accent h-5 w-5" />
              Upload Media Files
            </span>
          </div>
        </div>
      </section>

      <aside className="grid gap-5 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-3">
        {images?.length > 0 &&
          images.map((file: PreviewableFile) => (
            <PreviewImage
              key={file.id}
              file={file}
              closeHandler={() => closeImageHandler(file.id)}
            />
          ))}
      </aside>
    </div>
  )
}
