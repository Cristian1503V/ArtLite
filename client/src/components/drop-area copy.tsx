import { useEffect, useState } from "react"
import Image from "next/image"
import { cn } from "@/libs/utils"
import { DropEvent, FileRejection, useDropzone } from "react-dropzone"
import { Controller, useFormContext } from "react-hook-form"

import { PreviewableFile } from "@/config/types"

import { Icons } from "./icons"
import { PreviewImage } from "./preview-image"

type DropType = <T extends File>(
  acceptedFiles: T[],
  fileRejections: FileRejection[],
  event: DropEvent
) => void

export function DropArea() {
  const { control } = useFormContext()
  const [files, setFiles] = useState<PreviewableFile[]>([])

  const onDrop: DropType = (acceptedFiles) => {
    console.log(acceptedFiles)

    setFiles((currentFiles) => [
      ...currentFiles,
      ...acceptedFiles.map((file) =>
        Object.assign(file, {
          preview: URL.createObjectURL(file),
        })
      ),
    ])
  }

  const { getInputProps, getRootProps, isDragAccept, isDragReject, isFocused } =
    useDropzone({
      onDrop,
      accept: { "image/*": [] },
    })

  useEffect(() => {
    return () => files.forEach((file) => URL.revokeObjectURL(file.preview))
  }, [files])

  return (
    <div className="flex w-full flex-col  gap-8 px-4 py-6">
      <Controller
        name="images"
        control={control}
        render={({ field: { onChange, ref, name, onBlur } }) => (
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
              <input
                className="hidden"
                {...getInputProps()}
                // onChange={() => onChange(files)}
                onChange={onChange}
                ref={ref}
                name={name}
                onBlur={onBlur}
              />
              <div className="flex w-full items-center justify-center">
                <span className="hover:bg-muted flex cursor-pointer gap-2 rounded-md border border-[#303034] px-3 py-2 text-[14px] transition-all">
                  <Icons.image className="text-accent h-5 w-5" />
                  Upload Media Files
                </span>
              </div>
            </div>
          </section>
        )}
      />

      <aside className="grid gap-5 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-3">
        {files.map((file) => (
          <PreviewImage key={file.name} file={file} />
        ))}
      </aside>
    </div>
  )
}
